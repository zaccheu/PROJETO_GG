namespace GG.Communication.Requests;

public class RequestSalvarPedidoJson
{
    public DateTime Data { get; set; } = DateTime.Now;
    public int? IdCliente { get; set; }
    public int? Id { get; set; }
    public List<RequestItemPedidoJson> Itens { get; set; } = new();
}

public class RequestItemPedidoJson
{
    public int IdPrato { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}
