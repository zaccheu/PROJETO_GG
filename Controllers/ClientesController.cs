using CadastroClientes.Models;
using CadastroClientes.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Collections.Specialized;

namespace CadastroClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        
        [HttpPost("Salvar")]
        public IActionResult Salvar(Cliente cliente)
        {
            try
            {
                GGRepository clientess = new GGRepository();

                var retorno = clientess.GetClient(cliente.IdCliente);

                if (retorno != null)
                {
                    clientess.Atualizar(cliente);
                }
                else
                {
                    clientess.Salvar(cliente);
                }
            }
            catch (Exception ex)
            {

            }
            return Ok("Ok");
        }

        [HttpPost("Alterar")]
        public object Alterar([FromBody] Cliente cliente)
        {
            try
            {
                GGRepository clientes = new GGRepository();
                clientes.Atualizar(cliente);
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        [HttpGet("Listar")]
        public object Listar()
        {
            List<Cliente> listaCli = null;
            try
            {
                GGRepository clientesRepo = new GGRepository();
                listaCli = clientesRepo.Listar();

                if (listaCli == null)
                {
                    return NotFound("Nenhum cliente encontrado.");
                }
            }
            catch (Exception ex)
            {

            }
            return listaCli;
        }

        [HttpDelete("Deletar")]
        public object Deletar(int IdCliente)
        {
            try
            {
                GGRepository clientes = new GGRepository();
                bool retornoDelete = clientes.Deletar(IdCliente);

                return retornoDelete;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        [HttpGet("GetClient")]
        public object GetClient(int IdCliente)
        {
            List<Cliente> listaCli = null;
            try
            {
                GGRepository clientes = new GGRepository();
                var retorno = clientes.GetClient(IdCliente);
                return retorno;
            }
            catch (Exception ex)
            {

            }
            return listaCli;
        }
    }
}
