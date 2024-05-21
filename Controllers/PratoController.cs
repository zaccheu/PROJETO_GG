/*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//* Autor(es): 
//* Data da última modificação: 13/05/2024
//* Descrição: Controller para a entidade Prato
//* Testes: 
//* Anotações:
    - "Pratos" ou "Produtos"?
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

using CadastroClientes.Models;
using CadastroClientes.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace CadastroClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost("Inserir")]
        public IActionResult Inserir(Produtos produto)
        {
            try
            {
                PratosRepository produtosRepo = new PratosRepository();
                var existente = produtosRepo.ObterPorId(produto.IdProduto);

                if (existente != null)
                {
                    produtosRepo.Atualizar(produto);
                }
                else
                {
                    produtosRepo.Inserir(produto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok(produto);
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(Produtos produto)
        {
            try
            {
                PratosRepository produtosRepo = new PratosRepository();
                produtosRepo.Atualizar(produto);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return Ok();
        }

        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos()
        {
            List<Produtos> produtos = null;

            try
            {
                PratosRepository produtosRepo = new PratosRepository();
                produtos = produtosRepo.ListarTodos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);      
            }

            return Ok(produtos);
        }

        [HttpDelete("Deletar")]
        public IActionResult Deletar(int idProduto)
        {
            bool retorno = false;

            try
            {
                PratosRepository produtosRepo = new PratosRepository();
                retorno = produtosRepo.Deletar(idProduto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }

            return Ok(retorno);
        }

        [HttpGet("ObterPorId")]
        public IActionResult ObterPorId(int idProduto)
        {
            Produtos produto = null;

            try
            {
                PratosRepository produtosRepo = new PratosRepository();
                produto = produtosRepo.ObterPorId(idProduto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }

            return Ok(produto);
        }
    }
}