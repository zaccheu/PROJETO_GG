namespace CadastroClientes.Models;

public class PedidoProdutoDto
{
    public List<Produto>? IdProduto { get; set; }

    public List<int>? Quantidade { get; set; }

    public int IdCliente { get; set; }

    public int? IdPedido { get; set; }

    public DateTime Data { get; set; }
}
