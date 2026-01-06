using GG.Application.UseCases.Pedidos;
using GG.Communication.Requests;
using GG.Communication.Responses;
using GG.Communication.Responses.Pedido;
using Microsoft.AspNetCore.Mvc;

namespace GG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        [HttpPost("Salvar")]
        [ProducesResponseType(typeof(ResponsePedidoRegistradoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Salvar(
            [FromServices] IPedidoUseCase useCase,
            [FromBody] RequestSalvarPedidoJson pedido)
        {
            var retorno = await useCase.Salvar(pedido);

            return Created(string.Empty, retorno);
        }

        [HttpGet("Listar")]
        [ProducesResponseType(typeof(ResponsePedidoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<List<ResponsePedidoJson>> Listar(
            [FromServices] IPedidoUseCase useCase)
        {
            return await useCase.Listar();
        }

        [HttpDelete("Deletar")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<bool> Deletar(
            [FromServices] IPedidoUseCase useCase,
            [FromBody] int idPedido)
        {
            return await useCase.Deletar(idPedido);
        }
    }
}