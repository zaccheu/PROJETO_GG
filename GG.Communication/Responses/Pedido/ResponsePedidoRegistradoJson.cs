namespace GG.Communication.Responses.Pedido;

public class ResponsePedidoRegistradoJson
{
    public int IdPedido { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public bool Paga { get; set; }
    public int? IdCliente { get; set; }
}
