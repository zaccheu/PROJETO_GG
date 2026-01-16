namespace GG.Domain.Entity;

public class Despesa
{
    public int IdDespesa { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public bool Fixa { get; set; }
    public string? Nome { get; set; }
}