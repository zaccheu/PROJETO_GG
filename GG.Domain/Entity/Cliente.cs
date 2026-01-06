using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Domain.Entity;

[Table("Cliente")]
public class Cliente
{
    [Key]
    [Column("IdCliente")]
    public int IdCliente { get; set; }

    [Column("Nome")]
    public string Nome { get; set; }

    [Column("Telefone")]
    public string? Telefone { get; set; }

    [Column("Instagram")]
    public string? Instagram { get; set; }

    [Column("VIP")]
    public bool VIP { get; set; }

    // Navegação
    public virtual ICollection<Pedido> Pedidos { get; set; }
}