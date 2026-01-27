using GG.Application.UseCases.Pedidos;
using GG.Communication.Requests;
using GG.Communication.Responses;
using GG.Communication.Responses.Pedido;
using Microsoft.AspNetCore.Mvc;

namespace GG.Api.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        /// <summary>
        /// Cria um novo pedido com os itens especificados
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponsePedidoRegistradoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar(
            [FromServices] IPedidoUseCase useCase,
            [FromBody] RequestSalvarPedidoJson pedido)
        {
            var retorno = await useCase.Salvar(pedido);
            return CreatedAtAction(nameof(ObterPorId), new { id = retorno.IdPedido }, retorno);
        }

        /// <summary>
        /// Lista todos os pedidos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponsePedidoJson>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar([FromServices] IPedidoUseCase useCase)
        {
            var pedidos = await useCase.Listar();
            return Ok(pedidos);
        }

        /// <summary>
        /// Obtém os detalhes de um pedido específico
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponsePedidoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterPorId(
            [FromServices] IPedidoUseCase useCase,
            [FromRoute] int id)
        {
            var pedido = await useCase.ObterPorId(id);
            if (pedido == null)
                return NotFound(new { mensagem = "Pedido não encontrado." });

            return Ok(pedido);
        }

        /// <summary>
        /// Adiciona itens a um pedido existente
        /// </summary>
        [HttpPost("{id}/itens")]
        [ProducesResponseType(typeof(ResponsePedidoRegistradoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AdicionarItens(
            [FromServices] IPedidoUseCase useCase,
            [FromRoute] int id,
            [FromBody] RequestAdicionarItensPedidoJson request)
        {
            var retorno = await useCase.AdicionarItens(id, request);
            return Ok(retorno);
        }

        /// <summary>
        /// Remove um pedido
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deletar(
            [FromServices] IPedidoUseCase useCase,
            [FromRoute] int id)
        {
            var sucesso = await useCase.Deletar(id);
            if (!sucesso)
                return NotFound(new { mensagem = "Pedido não encontrado." });

            return NoContent();
        }
    }
}