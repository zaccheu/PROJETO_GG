using GG.Application.UseCases.Pratos;
using GG.Communication.Requests;
using GG.Communication.Responses;
using GG.Communication.Responses.Prato;
using Microsoft.AspNetCore.Mvc;

namespace GG.Api.Controllers
{
    [Route("api/pratos")]
    [ApiController]
    public class PratoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponsePratoRegistradoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar(
            [FromServices] IPratoUseCase useCase,
            [FromBody] RequestSalvarPratoJson prato)
        {
            var retorno = await useCase.Salvar(prato);

            return Created();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponsePratoJson>), StatusCodes.Status200OK)]
        public async Task<List<ResponsePratoJson>> Listar([FromServices] IPratoUseCase useCase)
        {
            return await useCase.Listar();
        }

        /// <summary>
        /// Obtém os detalhes de um prato ou bebida específico
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponsePratoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterPorId(
            [FromServices] IPratoUseCase useCase,
            [FromRoute] int id)
        {
            var prato = await useCase.ObterPorId(id);

            if (prato == null)
                return NotFound(new { mensagem = "Prato não encontrado." });

            return Ok(prato);
        }

        /// <summary>
        /// Atualiza um prato ou bebida existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponsePratoRegistradoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Atualizar(
            [FromServices] IPratoUseCase useCase,
            [FromRoute] int id,
            [FromBody] RequestSalvarPratoJson prato)
        {
            var retorno = await useCase.Atualizar(id, prato);
            return Ok(retorno);
        }

        /// <summary>
        /// Remove um prato ou bebida
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deletar(
            [FromServices] IPratoUseCase useCase,
            [FromRoute] int id)
        {
            var sucesso = await useCase.Deletar(id);

            if (!sucesso)
                return NotFound(new { mensagem = "Prato não encontrado." });

            return NoContent();
        }
    }
}