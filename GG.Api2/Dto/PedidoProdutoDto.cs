using GG.Domain.Entity;

namespace GG.Dto;

public class PedidoProdutoDto
{
    public List<Produto>? Produto { get; set; }

    public List<int>? Quantidade { get; set; }

    public int IdCliente { get; set; }

    public int? IdPedido { get; set; }

    public DateTime Data { get; set; }
}
