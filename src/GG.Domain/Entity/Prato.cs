namespace GG.Domain.Entity;

public class Prato
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    // Navegação
    public int PedidoPratoId { get; set; }
    public ICollection<PedidoPrato> PedidoPratos { get; set; } = null!;
    public int PratoProdutosId { get; set; }
    public ICollection<PratoProduto> PratoProdutos { get; set; } = null!;
}