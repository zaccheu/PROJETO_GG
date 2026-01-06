using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Domain.Entity;

[Table("Pratos")]
public class Prato
{
    [Key]
    [Column("IdPrato")]
    public int IdPrato { get; set; }

    [Column("Nome")]
    public string Nome { get; set; }

    [Column("Preco")]
    public decimal Preco { get; set; }

    // Navegação
    public virtual ICollection<PedidoPrato> PedidoPratos { get; set; }
    public virtual ICollection<PratoProduto> PratoProdutos { get; set; }
}