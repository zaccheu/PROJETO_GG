namespace GG.Domain.Entity;

public class Fornece
{
    public int Id { get; set; }
    public int FornecedorId { get; set; }
    public Fornecedor Fornecedor { get; set; } = null!;
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;
}