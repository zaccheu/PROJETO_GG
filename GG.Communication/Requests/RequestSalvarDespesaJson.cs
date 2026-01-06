namespace GG.Communication.Requests;

public class RequestSalvarDespesaJson
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public DateTime Data { get; set; }
    public bool Fixa { get; set; }
    public decimal Valor { get; set; }
}
