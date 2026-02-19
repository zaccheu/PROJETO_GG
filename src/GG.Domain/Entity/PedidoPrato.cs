namespace GG.Domain.Entity;

public class PedidoPrato
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    // Navegação
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; } = null!;
    public int PratoId { get; set; }
    public Prato Prato { get; set; } = null!;
}
