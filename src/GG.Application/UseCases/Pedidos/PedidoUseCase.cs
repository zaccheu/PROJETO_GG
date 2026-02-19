using AutoMapper;
using GG.Communication.Requests;
using GG.Communication.Responses.Pedido;
using GG.Domain.Entity;
using GG.Domain.Repositories;
using GG.Domain.Repositories.Pedidos;
using GG.Domain.Repositories.Prato;
using GG.Exception.ExceptionsBase;

namespace GG.Application.UseCases.Pedidos;

internal class PedidoUseCase : IPedidoUseCase
{
    private readonly IPedidoRepository _repository;
    private readonly IPratoRepository _pratoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PedidoUseCase(
        IPedidoRepository repository,
        IPratoRepository pratoRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _pratoRepository = pratoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    private void Validate(RequestSalvarPedidoJson request)
    {
        var validator = new PedidoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }

    public async Task<ResponsePedidoRegistradoJson> Salvar(RequestSalvarPedidoJson request)
    {
        Validate(request);

        Pedido pedido = _mapper.Map<Pedido>(request);

        // Adicionar os itens e calcular o valor total
        decimal valorTotal = 0;
        foreach (var item in request.Itens)
        {
            var prato = await _pratoRepository.GetById(item.IdPrato);
            if (prato == null)
                throw new NotFoundException($"Prato com ID {item.IdPrato} não encontrado.");

            var pedidoPrato = new Domain.Entity.PedidoPrato
            {
                Quantidade = item.Quantidade,
                Pedido = pedido,
                Prato = prato
            };

            pedido.PedidoPratos?.Add(pedidoPrato);
            valorTotal += prato.Preco * item.Quantidade;
        }

        pedido.Valor = valorTotal;

        await _repository.Add(pedido);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponsePedidoRegistradoJson>(pedido);
    }

    public async Task<List<ResponsePedidoJson>> Listar()
    {
        var lista = await _repository.GetAll();
        return _mapper.Map<List<ResponsePedidoJson>>(lista);
    }

    public async Task<ResponsePedidoJson?> ObterPorId(int idPedido)
    {
        var pedido = await _repository.GetByIdWithDetails(idPedido);
        if (pedido == null)
            return null;

        return _mapper.Map<ResponsePedidoJson>(pedido);
    }

    public async Task<ResponsePedidoRegistradoJson> AdicionarItens(int idPedido, RequestAdicionarItensPedidoJson request)
    {
        Pedido? pedido = await _repository.GetByIdWithDetails(idPedido);
        if (pedido == null)
            throw new NotFoundException("Pedido não encontrado.");

        pedido = _mapper.Map<Pedido>(request);

        pedido.Valor += pedido.PedidoPratos!.Sum(x => x.Prato.Preco);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponsePedidoRegistradoJson>(pedido);
    }

    public async Task<bool> Deletar(int idPedido)
    {
        var retorno = await _repository.Delete(idPedido);
        await _unitOfWork.Commit();

        return retorno;
    }
}

