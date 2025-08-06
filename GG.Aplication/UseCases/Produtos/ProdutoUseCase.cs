using AutoMapper;
using GG.Application.UseCases.Produtos;
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

        public async Task<ResponseProdutosRegistradosJson> Salvar(RequestSalvarProdutoJson produto)
        {
            Validate(produto);

            var entity = _mapper.Map<Produto>(produto);

            await _repository.Add(entity);

            await _unitOfWork.Commit();

            return _mapper.Map<ResponseProdutosRegistradosJson>(entity);
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

        //[HttpPost("Alterar")]
        //public RetornoAcao Alterar(Produto cliente)
        //{
        //    RetornoAcao retorno = new RetornoAcao();
        //    try
        //    {
        //        _context.Update(cliente);

        //        return retorno;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[HttpGet("Listar")]
        //public List<Produto> Listar()
        //{
        //    try
        //    {
        //        List<Produto> listaProduto = _context.Produtos
        //                                             .Include(c => c.Categoria)
        //                                             .ToList();

        //        if (listaProduto == null)
        //        {
        //            throw new Exception("Nenhum item encontrado!");
        //        }
        //        else
        //            return listaProduto;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[HttpDelete("Deletar")]
        //public RetornoAcao Deletar(int Id)
        //{
        //    RetornoAcao retorno = new RetornoAcao();
        //    Produto prato = new Produto();

        //    try
        //    {
        //        int id = _context.Produtos.Where(c => c.IdProduto == Id).Select(x => x.IdProduto).FirstOrDefault();

        //        if (id == 0)
        //        {
        //            retorno.Mensagem = "Produto não encontrado!";
        //        }
        //        else
        //        {
        //            _context.Remove(prato);
        //            _context.SaveChanges();
        //            retorno.Mensagem = "Produto deletado com sucesso!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno.Mensagem = ex.Message;
        //    }
        //    return retorno;
        //}
    }
}