using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GG.Domain.Entity;

[Table("Pedidos")]
public class Pedido
{
    [Key]
    [Column("IdPedido")]
    public int IdPedido { get; set; }

    [Column("Valor")]
    public decimal Valor { get; set; }

    [Column("Data")]
    public DateTime Data { get; set; }

    [Column("Paga")]
    public bool Paga { get; set; }

    [ForeignKey("IdCliente")]
    public int? IdCliente { get; set; }

    // Navegação
    public virtual Cliente? Cliente { get; set; }
    public virtual ICollection<PedidoPrato> PedidoPratos { get; set; }
}