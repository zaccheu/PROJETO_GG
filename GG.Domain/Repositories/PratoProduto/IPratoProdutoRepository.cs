using PratoProdutoEntity = GG.Domain.Entity.PratoProduto;

namespace GG.Domain.Repositories.PratoProduto;

public interface IPratoProdutoRepository
{
    Task Add(PratoProdutoEntity pedido);
    Task<bool> Delete(int idPedido);
    Task<List<PratoProdutoEntity>> GetAll();
}
