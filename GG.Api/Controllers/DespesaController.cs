using GG.Application.UseCases.Despesas;
using GG.Communication.Requests;
using GG.Communication.Responses;
using GG.Communication.Responses.Despesa;
using Microsoft.AspNetCore.Mvc;

namespace GG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        [HttpPost("Salvar")]
        [ProducesResponseType(typeof(ResponseDespesaRegistradaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Salvar(
            [FromServices] IDespesaUseCase useCase,
            [FromBody] RequestSalvarDespesaJson despesa)
        {
            var retorno = await useCase.Salvar(despesa);

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
        [ProducesResponseType(typeof(ResponseDespesaRegistradaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<List<ResponseDespesaJson>> Listar(
            [FromServices] IDespesaUseCase useCase)
        {
            return await useCase.Listar();
        }


        [HttpDelete("Deletar")]
        [ProducesResponseType(typeof(ResponseDespesaRegistradaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<bool> Deletar(
            [FromServices] IDespesaUseCase useCase,
            [FromBody] int idDespesa)
        {
            return await useCase.Deletar(idDespesa);
        }
    }
}
