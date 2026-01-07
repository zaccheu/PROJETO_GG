namespace GG.Communication.Requests;

public class RequestSalvarPratoJson
{
    public int? Id { get; set; }
    public string Nome { get; set; }
    public List<RequestSalvarProdutoJson> Produtos { get; set; } = new();
    public int IdPedido { get; set; }
    public DateTime DataPedido { get; set; } = DateTime.Now;
    public decimal? ValorTotal { get; set; }
}
