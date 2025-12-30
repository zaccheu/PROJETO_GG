using AutoMapper;
using GG.Communication.Responses;
using GG.Domain.Entity;
using GG.Domain.Repositories;
using GG.Domain.Repositories.Categorias;
using GG.Dto;
using GG.Exception.ExceptionsBase;
using System.Data;

namespace GG.Application.UseCases.Categorias;

public class CategoriaUseCase : ICategoriaUseCase
{
    private readonly ICategoriaRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriaUseCase(
        ICategoriaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    private void Validate(RequestSalvarCategoriaJson requestSalvarProdutoJson)
    {
        var validator = new CategoriaValidator();

        var result = validator.Validate(requestSalvarProdutoJson);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

    public async Task<ResponseCategoriaRegistradaJson> Salvar(RequestSalvarCategoriaJson categoria)
    {
        Validate(categoria);

        var entity = _mapper.Map<Categoria>(categoria);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseCategoriaRegistradaJson>(entity);
    }

    public async Task<List<ResponseCategoriaJson>> Listar()
    {
        var lista = _repository.GetAll();

        return _mapper.Map<List<ResponseCategoriaJson>>(lista);
    }

    public async Task<bool> Deletar(int idProduto)
    {
        var retorno = await _repository.Delete(idProduto);

        await _unitOfWork.Commit();

        return retorno;
    }
}