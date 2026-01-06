using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Domain.Entity;

[Table("PratoProduto")]
public class PratoProduto
{
    [Key]
    [Column("IdPrato")]
    [ForeignKey("Prato")]
    public int IdPrato { get; set; }

    [Key]
    [Column("IdProduto")]
    [ForeignKey("Produto")]
    public int IdProduto { get; set; }

    [Column("Quantidade")]
    public decimal Quantidade { get; set; }

    // Navegação
    public virtual Prato Prato { get; set; }
    public virtual Produto Produto { get; set; }
}