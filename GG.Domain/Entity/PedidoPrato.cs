namespace GG.Domain.Entity;

public class PedidoPrato
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }

    // Navegação
    public Pedido Pedido { get; set; } = null!;
    public Prato Prato { get; set; } = null!;
}
