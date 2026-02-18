using GG.Application.UseCases.Produtos;
using GG.Communication.Requests;
using GG.Communication.Responses;
using GG.Communication.Responses.Produto;
using Microsoft.AspNetCore.Mvc;

namespace GG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpPost("Salvar")]
        [ProducesResponseType(typeof(ResponseProdutoRegistradoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Salvar(
            [FromServices] IProdutoUseCase useCase,
            [FromBody] RequestSalvarProdutoJson categoria)
        {
            var retorno = await useCase.Salvar(categoria);

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

        //sem teste
        [HttpGet("Listar")]
        [ProducesResponseType(typeof(ResponseProdutoRegistradoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<List<ResponseProdutoJson>> Listar(
            [FromServices] IProdutoUseCase useCase)
        {
            return await useCase.Listar();
        }


        [HttpDelete("Deletar")]
        [ProducesResponseType(typeof(ResponseProdutoRegistradoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<bool> Deletar(
            [FromServices] IProdutoUseCase useCase,
            [FromBody] int idProduto)
        {
            return await useCase.Deletar(idProduto);
        }
    }
}
