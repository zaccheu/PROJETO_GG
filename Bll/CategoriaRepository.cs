using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using GG.Dto;
using GG.Entity;

namespace GG.Repository;

//responsável por salvar as coisas no banco de dados
public class CategoriaRepository
{
    //Crie uma instância de IConfiguration para carregar o appsettings.json
    IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

    private readonly MeuDbContext _context;

    // Injeção de dependência do DbContext
    public CategoriaRepository(MeuDbContext context)
    {
        _context = context;
    }

    public RetornoAcao Salvar(Categoria categoria)
    {
        RetornoAcao retorno = new RetornoAcao();
        try
        {
            if (categoria.IdCategoria != 0)
            {
                var clienteExiste = _context.Categorias
                                            .Where(c => c.IdCategoria == categoria.IdCategoria)
                                            .FirstOrDefault();

                ConverteEntity(clienteExiste, categoria);

                _context.Categorias.Update(clienteExiste);

                retorno.Mensagem = "Categoria atualizado com sucesso!";
            }
            else
            {
                _context.Categorias.Add(categoria);
                retorno.Mensagem = "Categoria salvo com sucesso!";
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
    public void Atualizar(Categoria categoria)
    {
        try
        {
            _context.Categorias.Update(categoria);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public List<Categoria> Listar()
    {

        List<Categoria> retorno = new List<Categoria>();

        try
        {
            retorno = _context.Categorias.ToList(); // Exemplo de execução de stored procedure

            return retorno;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public RetornoAcao Deletar(int IdCategoria)
    {
        RetornoAcao retorno = new RetornoAcao();
        try
        {
            Categoria cliente = _context.Categorias.Where(c => c.IdCategoria == IdCategoria).FirstOrDefault();

            if (cliente == null)
            {
                retorno.Mensagem = "Categoria não encontrada!";
            }
            else
            {
                _context.Remove(cliente);
                _context.SaveChanges();
                retorno.Mensagem = "Categoria deletada com sucesso!";
            }
        }
        catch (Exception ex)
        {
            retorno.Mensagem = ex.Message;
        }
        return retorno;
    }

    private Categoria ConverteEntity(Categoria existente, Categoria alterado)
    {
        existente.Nome = alterado.Nome;

        return existente;
    }
}

