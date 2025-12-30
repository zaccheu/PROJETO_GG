using GG.Application.UseCases.Categorias;
using GG.Communication.Responses;
using GG.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpPost("Salvar")]
        [ProducesResponseType(typeof(ResponseCategoriaRegistradaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Salvar(
            [FromServices] ICategoriaUseCase useCase,
            [FromBody] RequestSalvarCategoriaJson produto)
        {
            var retorno = await useCase.Salvar(produto);

            return Created(string.Empty, retorno);
        }



        //sem teste
        [HttpGet("Listar")]
        [ProducesResponseType(typeof(ResponseCategoriaRegistradaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<List<ResponseCategoriaJson>> Listar(
            [FromServices] ICategoriaUseCase useCase)
        {
            return await useCase.Listar();
        }

        [HttpDelete("Deletar")]
        [ProducesResponseType(typeof(ResponseCategoriaDeletadaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<bool> Deletar(
            [FromServices] ICategoriaUseCase useCase,
            [FromBody] int idCategoria)
        {
            return await useCase.Deletar(idCategoria);
        }
    }
}
