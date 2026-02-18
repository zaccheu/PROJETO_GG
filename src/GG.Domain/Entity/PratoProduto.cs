namespace GG.Domain.Entity;

public class PratoProduto
{
    public int Id { get; set; }
    public decimal Quantidade { get; set; }

    // Navegação

    public int PratoId { get; set; }
    public Prato Prato { get; set; } = null!;
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;
}