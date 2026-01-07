using GG.Application.UseCases.PedidoPrato;
using GG.Communication.Requests;
using GG.Communication.Responses;
using GG.Communication.Responses.PedidoPrato;
using Microsoft.AspNetCore.Mvc;

namespace GG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoPratoController : ControllerBase
    {
        [HttpPost("Salvar")]
        [ProducesResponseType(typeof(ResponsePedidoPratoRegistradoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Salvar(
            [FromServices] IPedidoPratoUseCase useCase,
            [FromBody] RequestSalvarPedidoPratoJson pedidoPrato)
        {
            var retorno = await useCase.Salvar(pedidoPrato);

            return Created(string.Empty, retorno);
        }

        // sem teste
        [HttpGet("Listar")]
        [ProducesResponseType(typeof(ResponsePedidoPratoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<List<ResponsePedidoPratoJson>> Listar(
            [FromServices] IPedidoPratoUseCase useCase)
        {
            return await useCase.Listar();
        }

        [HttpDelete("Deletar")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<bool> Deletar(
            [FromServices] IPedidoPratoUseCase useCase,
            [FromBody] int idPedido)
        {
            return await useCase.Deletar(idPedido);
        }
    }
}
