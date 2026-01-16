namespace GG.Domain.Entity;

public class Pedido
{
    public int IdPedido { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public bool Paga { get; set; }
    public int? IdCliente { get; set; }

    // Navegação
    public virtual Cliente? Cliente { get; set; }
    public virtual ICollection<PedidoPrato>? PedidoPratos { get; set; }
}