using AutoMapper;
using GG.Communication.Requests;
using GG.Communication.Responses.Produto;
using GG.Domain.Entity;
using GG.Domain.Repositories;
using GG.Domain.Repositories.Produtos;
using GG.Exception.ExceptionsBase;
using System.Data;

namespace GG.Application.UseCases.Produtos

{
    public class ProdutoUseCase : IProdutoUseCase
    {
        private readonly IProdutoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProdutoUseCase(
            IProdutoRepository repository,
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

        public async Task<ResponseProdutoRegistradoJson> Salvar(RequestSalvarProdutoJson produto)
        {
            Validate(produto);

            var entity = _mapper.Map<Produto>(produto);

            await _repository.Add(entity);

            await _unitOfWork.Commit();

            return _mapper.Map<ResponseProdutoRegistradoJson>(entity);
        }

        public async Task<List<ResponseProdutoJson>> Listar()
        {
            var lista = _repository.GetAll();

            return _mapper.Map<List<ResponseProdutoJson>>(lista);
        }

        public async Task<bool> Deletar(int idProduto)
        {
            var retorno = await _repository.Delete(idProduto);

            await _unitOfWork.Commit();

            return retorno;
        }
    }
}