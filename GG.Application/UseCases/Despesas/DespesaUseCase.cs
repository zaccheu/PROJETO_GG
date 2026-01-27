using AutoMapper;
using GG.Communication.Requests;
using GG.Communication.Responses.Despesa;
using GG.Domain.Entity;
using GG.Domain.Repositories;
using GG.Domain.Repositories.Despesas;
using GG.Exception.ExceptionsBase;

namespace GG.Application.UseCases.Despesas;

public class DespesaUseCase : IDespesaUseCase
{
    private readonly IDespesaRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DespesaUseCase(
        IDespesaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    private void Validate(RequestSalvarDespesaJson requestSalvarDespesaJson)
    {
        var validator = new DespesaValidator();

        var result = validator.Validate(requestSalvarDespesaJson);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

    public async Task<ResponseDespesaRegistradaJson> Salvar(RequestSalvarDespesaJson despesa)
    {
        Validate(despesa);

        var entity = _mapper.Map<Despesa>(despesa);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseDespesaRegistradaJson>(entity);
    }

    public async Task<List<ResponseDespesaJson>> Listar()
    {
        var lista = _repository.GetAll();

        return _mapper.Map<List<ResponseDespesaJson>>(lista);
    }

    public async Task<bool> Deletar(int idDespesa)
    {
        var retorno = await _repository.Delete(idDespesa);

        await _unitOfWork.Commit();

        return retorno;
    }
}