using AutoMapper;
using GG.Communication.Requests;
using GG.Communication.Responses.PedidoPrato;
using GG.Domain.Repositories;
using GG.Domain.Repositories.PedidoPrato;
using GG.Exception.ExceptionsBase;

namespace GG.Application.UseCases.PedidoPrato;

internal class PedidoPratoUseCase : IPedidoPratoUseCase
{
    private readonly IPedidoPratoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PedidoPratoUseCase(
        IPedidoPratoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    private void Validate(RequestSalvarPedidoPratoJson request)
    {
        var validator = new PedidoPratoValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

    public async Task<ResponsePedidoPratoRegistradoJson> Salvar(RequestSalvarPedidoPratoJson item)
    {
        Validate(item);

        var entity = _mapper.Map<Domain.Entity.PedidoPrato>(item);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponsePedidoPratoRegistradoJson>(entity);
    }

    public async Task<List<ResponsePedidoPratoJson>> Listar()
    {
        var lista = await _repository.GetAll();

        return _mapper.Map<List<ResponsePedidoPratoJson>>(lista);
    }

    public async Task<bool> Deletar(int idPedidoItem)
    {
        var retorno = await _repository.Delete(idPedidoItem);

        await _unitOfWork.Commit();

        return retorno;
    }
}
