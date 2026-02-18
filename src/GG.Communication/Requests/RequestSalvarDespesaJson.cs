namespace GG.Communication.Requests;

public class RequestSalvarDespesaJson
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public bool Fixa { get; set; } = false;
    public DateTime DataVencimento { get; set; }
}
