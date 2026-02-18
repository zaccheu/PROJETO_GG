namespace GG.Domain.Entity;

public class Despesa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public bool Fixa { get; set; }
    public DateTime DataVencimento { get; set; }
}