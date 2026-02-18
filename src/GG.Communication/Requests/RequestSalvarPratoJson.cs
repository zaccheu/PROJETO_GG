namespace GG.Communication.Requests;

public class RequestSalvarPratoJson
{
    public string Nome { get; set; } = string.Empty;
    public List<RequestSalvarPratoProdutoJson> Produtos { get; set; } = new();
    public decimal Preco { get; set; }
}
