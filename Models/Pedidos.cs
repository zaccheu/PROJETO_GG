namespace CadastroClientes.Models
{
    public class Pedidos
    {
        public int IdPedido { get; set; }
        public double valor { get; set; }
        public int idProduto { get; set; }
        public bool paga { get; set; }
        public string data { get; set; }
}
