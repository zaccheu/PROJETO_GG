using GG.Domain.Entity;

namespace GG.Domain.Repositories.Pedidos;

public interface IPedidosRepository
{
    Task Add(Pedido pedido);
}
