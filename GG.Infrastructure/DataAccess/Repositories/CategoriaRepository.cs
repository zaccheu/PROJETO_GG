using GG.Domain.Entity;
using GG.Domain.Repositories.Categorias;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess.Repositories;

internal class CategoriaRepository : ICategoriaRepository
{
    private readonly GGDbContext _dbContext;

    public CategoriaRepository(GGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Categoria categoria)
    {
        await _dbContext.Categorias.AddAsync(categoria);
    }

    public async Task<List<Categoria>> GetAll()
    {
        return await _dbContext.Categorias.ToListAsync();
    }

    public async Task<bool> Delete(int idCategoria)
    {
        Categoria? categoria = _dbContext.Categorias.Where(x => x.IdCategoria == idCategoria).FirstOrDefault();

        if (categoria != null)
        {
            _dbContext.Categorias.Remove(categoria);

            _dbContext.SaveChanges();

            return true;
        }

        return false;
    }
}
