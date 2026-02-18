namespace GG.Domain.Entity;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Instagram { get; set; }
    public bool VIP { get; set; } = false;
    // Navegação
    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}