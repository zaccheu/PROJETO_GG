/*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//* Autor(es): 
//* Data da última modificação: 30/04/2024
//* Descrição: Um ASP.NET Core Web API controller. Possui métodos para lidar com requests HTTP e manipulação/gerenciamento de dados 
//* Testes: 
//* Anotações:
    - Controller: determines what response to send back to a user when a user makes a browser request to the application.
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

using CadastroClientes.Bll;
using CadastroClientes.Models;
using CadastroClientes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PratoController : ControllerBase
    {
        private readonly PratoRepository _repository;

        public PratoController(PratoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Salvar")]
        public RetornoAcao Salvar(Produto prato)
        {
            RetornoAcao retorno = new RetornoAcao();
            try
            {
                _repository.Salvar(prato);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("Alterar")]
        public RetornoAcao Alterar([FromBody] Produto prato)
        {
            RetornoAcao retorno = new RetornoAcao();
            try
            {
                _repository.Alterar(prato);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public List<Produto> Listar()
        {
            List<Produto> listaPrato = null;
            try
            {
                listaPrato = _repository.Listar();

                if (listaPrato == null)
                {
                    throw new Exception("Nenhum prato encontrado!");
                }
                else
                    return listaPrato;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("Deletar")]
        public RetornoAcao Deletar(int idProduto)
        {
            RetornoAcao retorno = new RetornoAcao();

            try
            {
                retorno = _repository.Deletar(idProduto);
            }
            catch (Exception ex)
            {
                retorno.Mensagem = ex.Message;
            }
            return retorno;
        }
    }
}
