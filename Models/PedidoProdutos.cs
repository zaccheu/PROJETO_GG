namespace CadastroClientes.Models
{
    public class PedidoProdutos
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public float SubTotal { get; set; }
        public decimal? Desconto { get; set; }
    }
}
