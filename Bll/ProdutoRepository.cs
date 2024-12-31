/*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//* Autor(es): 
//* Data da última modificação: 13/05/2024
//* Descrição: Operações CRUD para a entidade Prato
//* Testes: 
//* Anotações:
    - "Produtos" ou "Produtos"?
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

using CadastroClientes.Controllers;
using CadastroClientes.Models;
using CadastroClientes.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace CadastroClientes.Bll
{
    public class ProdutoRepository
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        private readonly MeuDbContext _context;

        // Injeção de dependência do DbContext
        public ProdutoRepository(MeuDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public RetornoAcao Salvar(Produto prato)
        {
            RetornoAcao retorno = new RetornoAcao();
            try
            {
                if (prato.IdProduto != 0)
                {
                    var produtoExistente = _context.Produtos
                                                .Where(c => c.IdProduto == prato.IdProduto)
                                                .FirstOrDefault();
                    if (produtoExistente == null)
                    {
                        retorno.Mensagem = "Produto não encontrado!";
                    }

                    ConverteEntity(produtoExistente, prato);

                    _context.Produtos.Update(produtoExistente);

                    retorno.Mensagem = "Item atualizado com sucesso!";
                }
                else
                {
                    _context.Produtos.Add(prato);
                    retorno.Mensagem = "Produto salvo com sucesso!";
                }

                _context.SaveChanges();

                retorno.Ok = true;
            }
            catch (Exception ex)
            {
                retorno.Mensagem = "ERRO!";
            }
            return retorno;
        }

        [HttpPost("Alterar")]
        public RetornoAcao Alterar(Produto cliente)
        {
            RetornoAcao retorno = new RetornoAcao();
            try
            {
                _context.Update(cliente);

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
            try
            {
                List<Produto> listaCli = _context.Produtos.ToList();

                if (listaCli == null)
                {
                    throw new Exception("Nenhum item encontrado!");
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
        public RetornoAcao Deletar(int Id)
        {
            RetornoAcao retorno = new RetornoAcao();
            Produto prato = new Produto();

            try
            {
                int id = _context.Produtos.Where(c => c.IdProduto == Id).Select(x => x.IdProduto).FirstOrDefault();

                if (id == 0)
                {
                    retorno.Mensagem = "Produto não encontrado!";
                }
                else
                {
                    _context.Remove(prato);
                    _context.SaveChanges();
                    retorno.Mensagem = "Produto deletado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                retorno.Mensagem = ex.Message;
            }
            return retorno;
        }

        private Produto ConverteEntity(Produto existente, Produto alterado)
        {
            existente.Nome = alterado.Nome;
            existente.Descricao = alterado.Descricao;
            existente.Preco = alterado.Preco;
            existente.PrecoDescontado = alterado.PrecoDescontado;
            existente.Quantidade = alterado.Quantidade;

            return existente;
        }
    }
}