using GG.Dto;
using GG.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
