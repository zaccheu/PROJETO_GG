using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using GG.Dto;

namespace GG.Repository;

//responsável por salvar as coisas no banco de dados
public class DadosRepository
{
    //Crie uma instância de IConfiguration para carregar o appsettings.json
    IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

    private readonly MeuDbContext _context;

    // Injeção de dependência do DbContext
    public DadosRepository(MeuDbContext context)
    {
        _context = context;
    }

    //ok
    public RetornoDataMensal FaturamentoPorMes(MesPesquisaDto cliente)
    {
        RetornoDataMensal retorno = new RetornoDataMensal();
        try
        {
            retorno.FaturamentoMensal = _context.Pedidos
                                                .Where(x => x.Pago == true && x.Data.Month == cliente.Data.Month)
                                                .Sum(x => x.Valor);

            return retorno;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.InnerException.Message);
        }
    }

    public RetornoDataMensal FaturamentoPorCategoria(MesPesquisaDto dto)
    {
        RetornoDataMensal retorno = new RetornoDataMensal
        {
            FaturamentoCategoria = new List<FaturamentoCategoriaDto>()
        };
        try
        {
            List<FaturamentoCategoriaDto> faturamentoPorCategoria = _context.PedidoProduto
                                                                    .Where(x => x.Pedido.Data.Month == dto.Data.Month)
                                                                    .Include(pp => pp.Produto) // Inclui os dados dos produtos
                                                                    .ThenInclude(p => p.Categoria) // Inclui os dados das categorias
                                                                    .GroupBy(pp => pp.Produto.Categoria) // Agrupa por categoria
                                                                    .Select(grupo => new FaturamentoCategoriaDto
                                                                    {
                                                                        Categoria = grupo.Key,
                                                                        Faturamento = grupo.Sum(pp => pp.Produto.Preco * pp.Quantidade) // Soma o faturamento
                                                                    })
                                                                    .OrderByDescending(res => res.Faturamento) // Ordena por faturamento
                                                                    .ToList();

            if (faturamentoPorCategoria.Count > 0)
            {
                for (int i = 0; i < faturamentoPorCategoria.Count; i++)
                {
                    retorno.FaturamentoCategoria.Add(faturamentoPorCategoria[i]);
                }
            }
            else
            {
                throw new Exception("Nenhum dado encontrado");
            }
            return retorno;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.InnerException.Message);
        }
    }
}