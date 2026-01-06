namespace GG.Domain.Repositories.PedidoPrato;

public interface IPedidoPratoRepository
{
    Task Add(Entity.PedidoPrato pedido);
    Task<bool> Delete(int idPedido);
    Task<List<Entity.PedidoPrato>> GetAll();
}
