using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Domain.Entity;

[Table("PedidoPrato")]
public class PedidoPrato
{
    [Key]
    [Column("IdPedido")]
    [ForeignKey("Pedido")]
    public int IdPedido { get; set; }

    [Key]
    [Column("IdPrato")]
    [ForeignKey("Prato")]
    public int IdPrato { get; set; }

    [Column("Quantidade")]
    public int Quantidade { get; set; }

    [Column("Preco")]
    public decimal Preco { get; set; }

    // Navegação
    public virtual Pedido Pedido { get; set; }
    public virtual Prato Prato { get; set; }
}
