using GG.Application.UseCases.Produto;
using GG.Bll;
using GG.Communication.Responses;
using GG.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _repository;

        public ProdutoController(ProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Salvar")]
        [ProducesResponseType(typeof(ResponseProdutosRegistradosJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Salvar(
            [FromServices] IProdutoUseCase useCase,
            [FromBody] RequestSalvarProdutoJson produto)
        {
            var retorno = await useCase.Salvar(produto);

            return Created(string.Empty, retorno);
        }

        //[HttpPost("Alterar")]
        //public RetornoAcao Alterar([FromBody] Produto prato)
        //{
        //    RetornoAcao retorno = new RetornoAcao();
        //    try
        //    {
        //        _repository.Alterar(prato);

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
        //        List<Produto> listaProdutos = _repository.Listar();

        //        if (listaProdutos == null)
        //        {
        //            throw new Exception("Nenhum item encontrado!");
        //        }
        //        else
        //            return listaProdutos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[HttpDelete("Deletar")]
        //public RetornoAcao Deletar(int idProduto)
        //{
        //    RetornoAcao retorno = new RetornoAcao();
        //    try
        //    {
        //        retorno = _repository.Deletar(idProduto);
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno.Mensagem = ex.Message;
        //    }
        //    return retorno;
        //}
    }
}
