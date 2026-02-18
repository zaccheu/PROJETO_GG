using GG.Domain.Entity;

namespace GG.Domain.Repositories.Despesas;

public interface IDespesaRepository
{
    Task Add(Despesa pedido);
    Task<bool> Delete(int idPedido);
    Task<List<Despesa>> GetAll();
    Task<Despesa?> GetById(int id);
    void Update(Despesa entity);
}
