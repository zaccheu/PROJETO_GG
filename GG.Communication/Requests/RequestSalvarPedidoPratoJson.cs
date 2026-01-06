namespace GG.Communication.Requests;

public class RequestSalvarPedidoPratoJson
{
    public int? Id { get; set; }
    public List<RequestSalvarProdutoJson> Produtos { get; set; } = new();
    public DateTime DataPedido { get; set; } = DateTime.Now;
    public decimal? ValorTotal { get; set; }
}
