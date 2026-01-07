using PratoEntity = GG.Domain.Entity.Prato;

namespace GG.Domain.Repositories.Prato;

public interface IPratoRepository
{
    Task Add(PratoEntity pedido);
    Task<bool> Delete(int idPedido);
    Task<List<PratoEntity>> GetAll();
}
