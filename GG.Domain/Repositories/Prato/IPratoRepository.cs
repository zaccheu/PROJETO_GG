using PratoEntity = GG.Domain.Entity.Prato;

namespace GG.Domain.Repositories.Prato;

public interface IPratoRepository
{
    Task Add(PratoEntity prato);
    Task<bool> Delete(int idPrato);
    Task<List<PratoEntity>> GetAll();
    Task<PratoEntity?> GetById(int idPrato);
    void Update(PratoEntity prato);
}
