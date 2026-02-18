namespace GG.Communication.Requests
{
    public class RequestPedidoPratoJson
    {
        public int IdProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }
        //aditivos e observações podem ser adicionados futuramente
    }
}
