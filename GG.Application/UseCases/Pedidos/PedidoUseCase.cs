using AutoMapper;
using GG.Application.UseCases.Produtos;
using GG.Communication.Requests;
using GG.Communication.Responses.Pedido;
using GG.Domain.Repositories;
using GG.Domain.Repositories.Pedidos;
using GG.Exception.ExceptionsBase;

namespace GG.Application.UseCases.Pedidos;

internal class PedidoUseCase : IPedidoUseCase
{
    private readonly IPedidoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PedidoUseCase(
        IPedidoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    private void Validate(RequestSalvarPedidoJson requestSalvarPedidoJson)
    {
        var validator = new PedidoValidator();

        var result = validator.Validate(requestSalvarPedidoJson);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

    public async Task<ResponsePedidoRegistradoJson> Salvar(RequestSalvarPedidoJson produto)
    {
        Validate(produto);

        var entity = _mapper.Map<Pedido>(produto);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponsePedidoRegistradoJson>(entity);
    }

    public async Task<List<ResponsePedidoJson>> Listar()
    {
        var lista = _repository.GetAll();

        return _mapper.Map<List<ResponsePedidoJson>>(lista);
    }

    public async Task<bool> Deletar(int idPedido)
    {
        var retorno = await _repository.Delete(idPedido);

        await _unitOfWork.Commit();

        return retorno;
    }
}
