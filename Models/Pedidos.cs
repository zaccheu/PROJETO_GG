namespace CadastroClientes.Models
{
    public class Pedidos
    {
        public int IdPedido { get; set; }
        public double ValorTotal { get; set; }
        public int IdCliente { get; set; }
        public bool Pago { get; set; }
        //public DateTime Data { get; set; }
    }
}
