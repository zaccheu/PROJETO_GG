using GG.Domain.Entity;

namespace GG.Domain.Repositories.Pedidos;

public interface IProdutosRepository
{
    Task Add(Produto pedido);
    Task<List<Produto>> GetAll();
}
