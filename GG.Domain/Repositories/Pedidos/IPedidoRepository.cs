using GG.Domain.Entity;

namespace GG.Domain.Repositories.Pedidos;

public interface IPedidoRepository
{
    Task Add(Pedido pedido);
    Task<bool> Delete(int idPedido);
    Task<List<Pedido>> GetAll();
    Task<Pedido?> GetById(int idPedido);
    Task<Pedido?> GetByIdWithDetails(int idPedido);
    void Update(Pedido pedido);
}
