using CadastroClientes.Entity;
using CadastroClientes.Models;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Produtos")]
public class Produto
{
    [Column("IdProduto")]
    public int IdProduto { get; set; }
    
    [Column("Nome")]
    public string Nome { get; set; }
    
    [Column("Preco")]
    public decimal Preco { get; set; }

    [Column("PrecoDescontado")]
    public decimal? PrecoDescontado { get; set; }

    [Column("Quantidade")]
    public int Quantidade { get; set; }

    [Column("Descricao")]
    public string? Descricao { get; set; }

    [ForeignKey("IdCategoria")]
    public int IdCategoria { get; set; }

    public Categoria Categoria { get; set; }
}