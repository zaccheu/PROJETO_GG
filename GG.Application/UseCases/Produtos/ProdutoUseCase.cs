using AutoMapper;
using GG.Communication.Responses;
using GG.Domain.Entity;
using GG.Domain.Repositories;
using GG.Domain.Repositories.Produtos;
using GG.Dto;
using GG.Exception.ExceptionsBase;
using System.Data;

namespace GG.Application.UseCases.Produtos

{
    public class ProdutoUseCase : IProdutoUseCase
    {
        private readonly IProdutosRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProdutoUseCase(
            IProdutosRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private void Validate(RequestSalvarProdutoJson requestSalvarProdutoJson)
        {
            var validator = new ProdutoValidator();

            var result = validator.Validate(requestSalvarProdutoJson);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }

        public async Task<ResponseProdutosRegistradosJson> Salvar(RequestSalvarProdutoJson produto)
        {
            Validate(produto);

            var entity = _mapper.Map<Produto>(produto);

            await _repository.Add(entity);

            await _unitOfWork.Commit();

            return _mapper.Map<ResponseProdutosRegistradosJson>(entity);
        }

        public async Task<List<ResponseProdutosJson>> Listar()
        {
            var lista = _repository.GetAll();

            return _mapper.Map<List<ResponseProdutosJson>>(lista);
        }

        public async Task<bool> Deletar(int idProduto)
        {
            var retorno = await _repository.Delete(idProduto);

            await _unitOfWork.Commit();

            return retorno;
        }
    }
}