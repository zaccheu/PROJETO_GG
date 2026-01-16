namespace GG.Domain.Entity;

public class Fornece
{
    public int IdFornece { get; set; }
    public Fornecedor IdFornecedor { get; set; } = null!;
    public Produto Produto { get; set; } = null!;
}