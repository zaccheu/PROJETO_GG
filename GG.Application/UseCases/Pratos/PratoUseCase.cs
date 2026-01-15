using AutoMapper;
using GG.Communication.Requests;
using GG.Communication.Responses.Prato;
using GG.Domain.Entity;
using GG.Domain.Repositories;
using GG.Domain.Repositories.Prato;
using GG.Exception.ExceptionsBase;

namespace GG.Application.UseCases.Pratos;

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

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }

    public async Task<ResponsePratoRegistradoJson> Salvar(RequestSalvarPratoJson prato)
    {
        Validate(prato);

        var entity = _mapper.Map<Domain.Entity.Prato>(prato);

        await _repository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponsePratoRegistradoJson>(entity);
    }

    public async Task<List<ResponsePratoJson>> Listar()
    {
        var lista = await _repository.GetAll();
        return _mapper.Map<List<ResponsePratoJson>>(lista);
    }

    public async Task<ResponsePratoJson?> ObterPorId(int idPrato)
    {
        var prato = await _repository.GetById(idPrato);
        if (prato == null)
            return null;

        return _mapper.Map<ResponsePratoJson>(prato);
    }

    public async Task<ResponsePratoRegistradoJson> Atualizar(int idPrato, RequestSalvarPratoJson prato)
    {
        Validate(prato);

        var entity = await _repository.GetById(idPrato);
        if (entity == null)
            throw new NotFoundException("Prato não encontrado.");

        entity.Nome = prato.Nome;
        entity.Preco = prato.Preco;

        _repository.Update(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponsePratoRegistradoJson>(entity);
    }

    public async Task<bool> Deletar(int idPrato)
    {
        var retorno = await _repository.Delete(idPrato);
        await _unitOfWork.Commit();

        return retorno;
    }
}
