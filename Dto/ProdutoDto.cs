using CadastroClientes.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Dto;

public class ProdutoDto
{
    public int IdProduto { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public decimal? PrecoDescontado { get; set; }
    public int Quantidade { get; set; }
    public string? Descricao { get; set; }
    public string Categoria { get; set; }
}
