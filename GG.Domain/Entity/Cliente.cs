namespace GG.Domain.Entity;

public class Cliente
{
    public int IdCliente { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Instagram { get; set; }
    public bool VIP { get; set; }
    // Navegação
    public virtual ICollection<Pedido> Pedidos { get; set; } = null!;
}