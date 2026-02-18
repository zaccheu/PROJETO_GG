namespace GG.Domain.Entity;

public class Fornecedor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Contato { get; set; }
    public string? Endereco { get; set; }

    // Navegação
    public ICollection<Fornece>? Fornecimentos { get; set; }
}