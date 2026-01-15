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

    public async Task<ResponsePedidoRegistradoJson> Salvar(RequestSalvarPedidoJson pedido)
    {
        Validate(pedido);

        // Criar o pedido
        var entity = new Pedido
        {
            Data = pedido.Data,
            IdCliente = pedido.IdCliente,
            Paga = false,
            Valor = 0,
            PedidoPratos = new List<Domain.Entity.PedidoPrato>()
        };

        // Adicionar os itens e calcular o valor total
        decimal valorTotal = 0;
        foreach (var item in pedido.Itens)
        {
            var prato = await _pratoRepository.GetById(item.IdPrato);
            if (prato == null)
                throw new NotFoundException($"Prato com ID {item.IdPrato} não encontrado.");

            var pedidoPrato = new Domain.Entity.PedidoPrato
            {
                IdPrato = item.IdPrato,
                Quantidade = item.Quantidade,
                Preco = prato.Preco
            };

            entity.PedidoPratos.Add(pedidoPrato);
            valorTotal += prato.Preco * item.Quantidade;
        }

        entity.Valor = valorTotal;

        await _repository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponsePedidoRegistradoJson>(entity);
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
        var pedido = await _repository.GetByIdWithDetails(idPedido);
        if (pedido == null)
            throw new NotFoundException("Pedido não encontrado.");

        decimal valorAdicional = 0;
        foreach (var item in request.Itens)
        {
            var prato = await _pratoRepository.GetById(item.IdPrato);
            if (prato == null)
                throw new NotFoundException($"Prato com ID {item.IdPrato} não encontrado.");

            var pedidoPrato = new Domain.Entity.PedidoPrato
            {
                IdPedido = idPedido,
                IdPrato = item.IdPrato,
                Quantidade = item.Quantidade,
                Preco = prato.Preco
            };

            pedido.PedidoPratos.Add(pedidoPrato);
            valorAdicional += prato.Preco * item.Quantidade;
        }

        pedido.Valor += valorAdicional;
        _repository.Update(pedido);
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

