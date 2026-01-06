using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Domain.Entity;

[Table("Fornecedor")]
public class Fornecedor
{
    [Key]
    [Column("IdFornecedor")]
    public int IdFornecedor { get; set; }

    [Column("Nome")]
    public string Nome { get; set; }

    [Column("Contato")]
    public string? Contato { get; set; }

    [Column("Endereco")]
    public string? Endereco { get; set; }

    // Navegação
    public virtual ICollection<Fornece> Fornecimentos { get; set; }
}