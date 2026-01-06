using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Domain.Entity;

[Table("Produtos")]
public class Produto
{
    [Key]
    [Column("IdProduto")]
    public int IdProduto { get; set; }

    [Column("Nome")]
    public string Nome { get; set; }

    [Column("Preco")]
    public decimal Preco { get; set; }

    [Column("QuantidadeAtual")]
    public decimal QuantidadeAtual { get; set; }

    [Column("UnidadeDeMedida")]
    public string UnidadeDeMedida { get; set; }

    // Navegação
    public virtual ICollection<PratoProduto> PratoProdutos { get; set; }
    public virtual ICollection<Fornece> Fornecimentos { get; set; }
}