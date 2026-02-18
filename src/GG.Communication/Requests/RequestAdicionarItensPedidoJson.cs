namespace GG.Communication.Requests;

public class RequestAdicionarItensPedidoJson
{
    public List<RequestItemPedidoJson> Itens { get; set; } = new();
}
