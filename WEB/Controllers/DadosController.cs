using CadastroClientes.Dto;
using CadastroClientes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.WEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DadosController : ControllerBase
{
    private readonly DadosRepository _repository;

    public DadosController(DadosRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("FaturamentoPorCategoria")]
    public RetornoDataMensal FaturamentoPorCategoria(MesPesquisaDto dtoPesquisa)
    {
        RetornoDataMensal retorno = new RetornoDataMensal();
        try
        {
            retorno = _repository.FaturamentoPorCategoria(dtoPesquisa);

            return retorno;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}