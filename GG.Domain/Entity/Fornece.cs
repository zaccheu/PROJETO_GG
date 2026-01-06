using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Domain.Entity;

[Table("Fornece")]
public class Fornece
{
    [Key]
    [Column("IdFornecedor")]
    [ForeignKey("Fornecedor")]
    public int IdFornecedor { get; set; }

    [Key]
    [Column("IdProduto")]
    [ForeignKey("Produto")]
    public int IdProduto { get; set; }

    // Navegação
    public virtual Fornecedor Fornecedor { get; set; }
    public virtual Produto Produto { get; set; }
}