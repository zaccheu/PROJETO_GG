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
    public class PedidoProdutoRepository
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        private readonly MeuDbContext _context;

        // Injeção de dependência do DbContext
        public PedidoProdutoRepository(MeuDbContext context)
        {
            _context = context;
        }

        [HttpPost("Salvar")]
        public RetornoAcao Salvar(PedidoProdutoDto dto)
        {
            RetornoAcao retorno = new RetornoAcao();

            try
            {
                TimeZoneInfo timezoneBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                DateTime dataBrasilia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezoneBrasilia);

                if (dto.IdProduto != null && dto.Quantidade != null && dto.IdProduto.Count == dto.Quantidade.Count)
                {
                    decimal ValorTotal = 0;

                    Pedido pedido = new Pedido
                    {
                        Data = dto.Data,
                        IdCliente = dto.IdCliente,
                        Pago = false
                    };

                    _context.Pedidos.Add(pedido);
                    _context.SaveChanges();  // Salva o pedido primeiro para garantir o IdPedido gerado

                    for (int i = 0; i < dto.IdProduto.Count; i++)
                    {
                        PedidoProduto pedidoProduto = new PedidoProduto
                        {
                            IdPedido = pedido.IdPedido,  // Atribui o Id do pedido que foi gerado
                            IdProduto = dto.IdProduto[i].IdProduto,
                            Quantidade = dto.Quantidade[i]
                        };

                        // Calculando o valor total
                        ValorTotal += dto.IdProduto[i].Preco * pedidoProduto.Quantidade;

                        _context.PedidoProduto.Add(pedidoProduto);
                    }

                    pedido.Valor = ValorTotal;
                    _context.SaveChanges();  // Salvando as alterações no Pedido e PedidoProduto

                    retorno.Ok = true;
                    retorno.Mensagem = $"Pedido gerado com sucesso! Valor total: R$ ${ValorTotal.ToString("F2")}";
                }
                else
                {
                    retorno.Mensagem = "Nenhum produto selecionado ou quantidade inválida!";
                }
            }
            catch (Exception ex)
            {
                retorno.Mensagem = "ERRO: " + ex.Message;
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
        public List<PedidoProduto> Listar()
        {
            try
            {
                List<PedidoProduto> listaCli = _context.PedidoProduto.ToList();

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