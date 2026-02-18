using GG.Domain.Entity;
using GG.Domain.Repositories.Prato;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess.Repositories;

internal class PratoRepository : IPratoRepository
{
    private readonly GGDbContext _dbContext;
    
    public PratoRepository(GGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Prato prato) => await _dbContext.Pratos.AddAsync(prato);

    public async Task<List<Prato>> GetAll() => 
        await _dbContext.Pratos
            .AsNoTracking()
            .ToListAsync();

    public async Task<Prato?> GetById(int idPrato) =>
        await _dbContext.Pratos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == idPrato);

    public void Update(Prato prato) => _dbContext.Pratos.Update(prato);

    public async Task<bool> Delete(int idPrato)
    {
        var prato = await _dbContext.Pratos
            .FirstOrDefaultAsync(x => x.Id == idPrato);

        if (prato != null)
        {
            _dbContext.Pratos.Remove(prato);
            return true;
        }

        return false;
    }
}
