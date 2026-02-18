namespace GG.Communication.Responses.Despesa;

public class ResponseDespesaRegistradaJson
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime? DataVencimento { get; set; }
    public bool Fixa {  get; set; }
}
