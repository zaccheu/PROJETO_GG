using GG.Domain.Entity;

namespace GG.Domain.Repositories.Categorias;

public interface ICategoriaRepository
{
    Task Add(Categoria pedido);
    Task<bool> Delete(int idCategoria);
    Task<List<Categoria>> GetAll();
}
