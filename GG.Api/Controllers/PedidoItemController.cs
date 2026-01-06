//using GG.Application.UseCases.Pedidos;
//using GG.Communication.Responses;
//using GG.Dto;
//using Microsoft.AspNetCore.Mvc;

//namespace GG.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PedidoItemController : ControllerBase
//    {
//        [HttpPost("Salvar")]
//        [ProducesResponseType(typeof(ResponsePedidoItemRegistradoJson), StatusCodes.Status201Created)]
//        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
//        public async Task<IActionResult> Salvar(
//            [FromServices] IPedidoItemUseCase useCase,
//            [FromBody] RequestSalvarPedidoItemJson item)
//        {
//            var retorno = await useCase.Salvar(item);

//            return Created(string.Empty, retorno);
//        }   

//        [HttpGet("Listar")]
//        [ProducesResponseType(typeof(ResponsePedidoItemJson), StatusCodes.Status200OK)]
//        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
//        public async Task<List<ResponsePedidoItemJson>> Listar(
//            [FromServices] IPedidoItemUseCase useCase)
//        {
//            return await useCase.Listar();
//        }

//        [HttpDelete("Deletar")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
//        public async Task<bool> Deletar(
//            [FromServices] IPedidoItemUseCase useCase,
//            [FromBody] int idPedidoItem)
//        {
//            return await useCase.Deletar(idPedidoItem);
//        }
//    }
//}