namespace GG.Domain.Entity;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public decimal QuantidadeAtual { get; set; }
    public string UnidadeDeMedida { get; set; } = string.Empty;

    // Navegação
    public ICollection<PratoProduto>? PratoProdutos { get; set; }
    public ICollection<Fornece>? Fornecimentos { get; set; }
}