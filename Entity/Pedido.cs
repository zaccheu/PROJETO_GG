using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models;

[Table("Pedidos")]
public class Pedido
{
    [Column("IdPedido")]
    public int IdPedido { get; set; }

    [Column("Data")]
    public DateTime Data { get; set; } 

    [ForeignKey("Cliente")]
    public int IdCliente { get; set; }

    [Column("Valor")]
    public decimal Valor { get; set; }

    [Column("Pago")]
    public bool Pago { get; set; }

    public ICollection<PedidoProduto> PedidoProdutos { get; set; }  // Produtos do pedido
}
