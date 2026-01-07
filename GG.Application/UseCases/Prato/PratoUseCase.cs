using AutoMapper;
using GG.Application.UseCases.Prato;
using GG.Communication.Requests;
using GG.Communication.Responses.Prato;
using GG.Domain.Repositories;
using GG.Domain.Repositories.Prato;
using GG.Exception.ExceptionsBase;

namespace GG.Application.UseCases.PedidoPrato;

internal class PratoUseCase : IPratoUseCase
{
    private readonly IPratoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PratoUseCase(
        IPratoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    private void Validate(RequestSalvarPratoJson request)
    {
        var validator = new PratoValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

    public async Task<ResponsePratoRegistradoJson> Salvar(RequestSalvarPratoJson item)
    {
        Validate(item);

        var entity = _mapper.Map<Domain.Entity.Prato>(item);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponsePratoRegistradoJson>(entity);
    }

    public async Task<List<ResponsePratoJson>> Listar()
    {
        var lista = await _repository.GetAll();

        return _mapper.Map<List<ResponsePratoJson>>(lista);
    }

    public async Task<bool> Deletar(int idPrato)
    {
        var retorno = await _repository.Delete(idPrato);

        await _unitOfWork.Commit();

        return retorno;
    }
}
