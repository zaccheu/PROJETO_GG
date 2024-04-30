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
        //Crie uma instância de IConfiguration para carregar o appsettings.json
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        [HttpPost("Salvar")]
        public object Salvar([FromBody] Cliente cliente)
        {
            try
            {
                var appConfig = new AppConnection(configuration);

                ClientesRepository clientess = new ClientesRepository(appConfig);

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
            return null;
        }

        [HttpPost("Alterar")]
        public object Alterar([FromBody] Cliente cliente)
        {
            try
            {
                var appConfig = new AppConnection(configuration);

                ClientesRepository clientes = new ClientesRepository(appConfig);
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
                var appConfig = new AppConnection(configuration);

                ClientesRepository clientesRepo = new ClientesRepository(appConfig);
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
                var appConfig = new AppConnection(configuration);

                ClientesRepository clientes = new ClientesRepository(appConfig);
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
                var appConfig = new AppConnection(configuration);

                ClientesRepository clientes = new ClientesRepository(appConfig);
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
