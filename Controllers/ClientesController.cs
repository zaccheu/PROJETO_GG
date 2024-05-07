using CadastroClientes.Models;
using CadastroClientes.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
                ClienteRepository clientess = new ClienteRepository();

                var retorno = clientess.GetClient(cliente.Telefone);

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
            //return Ok("Ok");
            return Ok(cliente);
        }

        [HttpPost("Alterar")]
        public object Alterar([FromBody] Cliente cliente)
        {
            try
            {
                ClienteRepository clientes = new ClienteRepository();
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
                ClienteRepository clientesRepo = new ClienteRepository();
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
        public object Deletar(string Telefone)
        {
            try
            {
                ClienteRepository clientes = new ClienteRepository();
                bool retornoDelete = clientes.Deletar(Telefone);

                return retornoDelete;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        [HttpGet("GetClient")]
        public object GetClient(string telefone)
        {
            List<Cliente> listaCli = null;
            try
            {
                ClienteRepository clientes = new ClienteRepository();
                var retorno = clientes.GetClient(telefone);
                return retorno;
            }
            catch (Exception ex)
            {

            }
            return listaCli;
        }
    }
}
