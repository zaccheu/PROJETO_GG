using CadastroClientes.Bll;
using CadastroClientes.Dto;
using CadastroClientes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoProdutoController : ControllerBase
    {
        private readonly PedidoProdutoRepository _repository;

        public PedidoProdutoController(PedidoProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Salvar")]
        public RetornoAcao Salvar(PedidoProdutoDto prato)
        {
            try
            {
                RetornoAcao retorno = _repository.Salvar(prato);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("EditarPedido")]
        public RetornoAcao EditarPedido(PedidoProdutoDto dto)
        {
            try
            {
                RetornoAcao retorno = _repository.EditarPedido(dto);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public List<PedidoProduto> Listar()
        {
            try
            {
                List<PedidoProduto> listaPedido = _repository.Listar();

                if (listaPedido == null)
                {
                    throw new Exception("Nenhum item encontrado!");
                }
                else
                    return listaPedido;
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
