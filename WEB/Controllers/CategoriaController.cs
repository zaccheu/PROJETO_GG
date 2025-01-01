using CadastroClientes.Bll;
using CadastroClientes.Dto;
using CadastroClientes.Entity;
using CadastroClientes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.WEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly CategoriaRepository _repository;

    public CategoriaController(CategoriaRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("Salvar")]
    public RetornoAcao Salvar(Categoria categoria)
    {
        RetornoAcao retorno = new RetornoAcao();
        try
        {
            retorno = _repository.Salvar(categoria);

            return retorno;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    [HttpGet("Listar")]
    public List<Categoria> Listar()
    {
        List<Categoria> listaCategoria = null;
        try
        {
            listaCategoria = _repository.Listar();

            if (listaCategoria == null)
            {
                throw new Exception("Nenhum categoria encontrada!");
            }
            else
                return listaCategoria;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("Deletar")]
    public object Deletar(int IdCategoria)
    {
        RetornoAcao retorno = new RetornoAcao();
        try
        {
            retorno = _repository.Deletar(IdCategoria);
        }
        catch (Exception ex)
        {
            retorno.Mensagem = ex.Message;
        }
        return retorno;
    }
}