namespace GG.Communication.Responses.Pedido;

public class ResponsePedidoJson
{
    public int IdPedido { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public bool Paga { get; set; }
    public int? IdCliente { get; set; }
    public List<ResponseItemPedidoJson> Itens { get; set; } = new();
}

public class ResponseItemPedidoJson
{
    public int IdPrato { get; set; }
    public string NomePrato { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
    public decimal Subtotal => Quantidade * Preco;
}
