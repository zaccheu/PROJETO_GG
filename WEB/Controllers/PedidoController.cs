using CadastroClientes.Bll;
using CadastroClientes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _repository;

        public PedidoController(PedidoRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("PagarPedido")]
        public RetornoAcao PagarPedido(int IdPedido)
        {
            try
            {
                RetornoAcao retorno = _repository.PagarPedido(IdPedido);

                if (retorno == null)
                {
                    throw new Exception("Nenhum item encontrado!");
                }
                else
                    return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
