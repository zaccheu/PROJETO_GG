namespace GG.Domain.Entity;

public class PratoProduto
{
    public int Id { get; set; }
    public decimal Quantidade { get; set; }

    // Navegação
    public Prato Prato { get; set; } = null!;
    public Produto Produto { get; set; } = null!;
}