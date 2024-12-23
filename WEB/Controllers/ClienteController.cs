/*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//* Autor(es): 
//* Data da última modificação: 30/04/2024
//* Descrição: Um ASP.NET Core Web API controller. Possui métodos para lidar com requests HTTP e manipulação/gerenciamento de dados 
//* Testes: 
//* Anotações:
    - Controller: determines what response to send back to a user when a user makes a browser request to the application.
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

using CadastroClientes.Models;
using CadastroClientes.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CadastroClientes.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _repository;

        public ClienteController(ClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Salvar")]
        public RetornoAcao Salvar(Cliente cliente)
        {
            RetornoAcao retorno = new RetornoAcao();
            try
            {
                retorno = _repository.Salvar(cliente);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public List<Cliente> Listar()
        {
            List<Cliente> listaCli = null;
            try
            {
                listaCli = _repository.Listar();

                if (listaCli == null)
                {
                    throw new Exception("Nenhum cliente encontrado!");
                }
                else
                    return listaCli;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("Deletar")]
        public object Deletar(string Telefone)
        {
            RetornoAcao retorno = new RetornoAcao();
            try
            {
                retorno = _repository.Deletar(Telefone);
            }
            catch (Exception ex)
            {
                retorno.Mensagem = ex.Message;
            }
            return retorno;
        }

        [HttpDelete("Inativar")]
        public object Inativar(Cliente cliente)
        {
            RetornoAcao retorno = new RetornoAcao();
            try
            {
                retorno = _repository.Inativar(cliente);
            }
            catch (Exception ex)
            {
                retorno.Mensagem = ex.Message;
            }
            return retorno;
        }

        [HttpGet("GetClient")]
        public Cliente GetClient(string telefone)
        {
            Cliente cliente = null;
            try
            {
                cliente = _repository.GetClient(telefone);

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
