using PedidoPratoEntity = GG.Domain.Entity.PedidoPrato;

namespace GG.Domain.Repositories.PedidoPrato;

public interface IPedidoPratoRepository
{
    Task Add(PedidoPratoEntity pedido);
    Task<bool> Delete(int idPedido);
    Task<List<PedidoPratoEntity>> GetAll();
}
