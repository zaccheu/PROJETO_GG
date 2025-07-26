using GG.Dto;
using GG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GG.Bll
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

                if (dto.Produto != null && dto.Quantidade != null && dto.Produto.Count == dto.Quantidade.Count)
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

                    for (int i = 0; i < dto.Produto.Count; i++)
                    {
                        PedidoProduto pedidoProduto = new PedidoProduto
                        {
                            IdPedido = pedido.IdPedido,  // Atribui o Id do pedido que foi gerado
                            IdProduto = dto.Produto[i].IdProduto,
                            Quantidade = dto.Quantidade[i]
                        };

                        // Calculando o valor total
                        ValorTotal += dto.Produto[i].Preco * pedidoProduto.Quantidade;

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


        [HttpPost("EditarPedido")]
        public RetornoAcao EditarPedido(PedidoProdutoDto dto)
        {
            RetornoAcao retorno = new RetornoAcao();

            try
            {
                // Verifica se o pedido existe
                var pedido = _context.Pedidos.FirstOrDefault(p => p.IdPedido == dto.IdPedido);
                if (pedido == null)
                {
                    retorno.Mensagem = "Pedido não encontrado!";
                    return retorno;
                }

                decimal ValorTotal = pedido.Valor; // Valor atual do pedido

                // Adicionar ou atualizar itens
                if (dto.Produto != null && dto.Quantidade != null && dto.Produto.Count == dto.Quantidade.Count)
                {
                    for (int i = 0; i < dto.Produto.Count; i++)
                    {
                        int idProduto = dto.Produto[i].IdProduto;
                        int quantidade = dto.Quantidade[i];

                        // Verifica se o item já está no pedido
                        var pedidoProdutoExistente = _context.PedidoProduto
                            .FirstOrDefault(pp => pp.IdPedido == pedido.IdPedido && pp.IdProduto == idProduto);

                        if (pedidoProdutoExistente != null)
                        {
                            // Atualiza a quantidade do item existente
                            ValorTotal -= pedidoProdutoExistente.Quantidade * dto.Produto[i].Preco;
                            pedidoProdutoExistente.Quantidade = quantidade;
                            ValorTotal += quantidade * dto.Produto[i].Preco;
                        }
                        else
                        {
                            // Adiciona novo item
                            PedidoProduto novoPedidoProduto = new PedidoProduto
                            {
                                IdPedido = pedido.IdPedido,
                                IdProduto = idProduto,
                                Quantidade = quantidade
                            };

                            ValorTotal += quantidade * dto.Produto[i].Preco;
                            _context.PedidoProduto.Add(novoPedidoProduto);
                        }
                    }
                }

                // Remover itens (caso dto.IdProduto não inclua todos os itens do pedido atual)
                var itensAtuais = _context.PedidoProduto.Where(pp => pp.IdPedido == pedido.IdPedido).Include(pp => pp.Produto).ToList();

                foreach (var item in itensAtuais)
                {
                    if (!dto.Produto.Any(p => p.IdProduto == item.IdProduto))
                    {
                        ValorTotal -= item.Quantidade * item.Produto.Preco; // Subtrai o valor do item removido
                        _context.PedidoProduto.Remove(item);
                    }
                }

                // Atualiza o valor total do pedido
                pedido.Valor = ValorTotal;
                _context.SaveChanges();

                retorno.Ok = true;
                retorno.Mensagem = $"Pedido atualizado com sucesso! Novo valor total: R$ {ValorTotal.ToString("F2")}";
            }
            catch (Exception ex)
            {
                retorno.Mensagem = "ERRO: " + ex.Message;
            }
            return retorno;
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