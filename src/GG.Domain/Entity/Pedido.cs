namespace GG.Domain.Entity;

public class Pedido
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime? Data { get; set; }
    public bool Paga { get; set; } = false;
    public int ClienteId { get; set; }
    // Navegação
    public Cliente? Cliente { get; set; }
    public int PedidoPratosId { get; set; }
    public ICollection<PedidoPrato>? PedidoPratos { get; set; }
}