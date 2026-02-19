namespace GG.Domain.Entity;

public class Prato
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    // Navegação
    public ICollection<PedidoPrato?> PedidoPratos { get; set; } = null!;
    public ICollection<PratoProduto?> PratoProdutos { get; set; } = null!;
}