using AutoMapper;
using GG.Communication.Requests;
using GG.Communication.Responses.PratoProduto;
using GG.Domain.Repositories;
using GG.Domain.Repositories.PratoProduto;
using GG.Exception.ExceptionsBase;

namespace GG.Application.UseCases.PratoProduto;

internal class PratoProdutoUseCase : IPratoProdutoUseCase
{
    private readonly IPratoProdutoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PratoProdutoUseCase(
        IPratoProdutoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    private void Validate(RequestSalvarPratoProdutoJson request)
    {
        var validator = new PratoProdutoValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

    public async Task<ResponsePratoProdutoRegistradoJson> Salvar(RequestSalvarPratoProdutoJson item)
    {
        Validate(item);

        var entity = _mapper.Map<Domain.Entity.PratoProduto>(item);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponsePratoProdutoRegistradoJson>(entity);
    }

    public async Task<List<ResponsePratoProdutoJson>> Listar()
    {
        var lista = await _repository.GetAll();

        return _mapper.Map<List<ResponsePratoProdutoJson>>(lista);
    }

    public async Task<bool> Deletar(int idPedidoItem)
    {
        var retorno = await _repository.Delete(idPedidoItem);

        await _unitOfWork.Commit();

        return retorno;
    }
}
