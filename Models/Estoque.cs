namespace CadastroClientes.Models
{
    public class Estoque
    {
        public int idProduto { get; set; }
        public string name { get; set; }
        public double preço { get; set; }
        public double quantidadeKG { get; set; }
        public int quantidadeUnidades { get; set; }
    }
}
