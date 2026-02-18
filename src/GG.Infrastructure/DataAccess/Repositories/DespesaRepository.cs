using GG.Domain.Entity;
using GG.Domain.Repositories.Despesas;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess.Repositories;

internal class DespesaRepository : IDespesaRepository
{
    private readonly GGDbContext _dbContext;

    public DespesaRepository(GGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Despesa despesa) => await _dbContext.Despesas.AddAsync(despesa);

    public async Task<List<Despesa>> GetAll() => await _dbContext.Despesas.ToListAsync();

    public async Task<Despesa?> GetById(int id) => await _dbContext.Despesas.FirstOrDefaultAsync(x => x.Id == id);

    public void Update(Despesa despesa) => _dbContext.Despesas.Update(despesa);

    public async Task<bool> Delete(int idDespesa)
    {
        Despesa? despesa = await _dbContext.Despesas.Where(x => x.Id == idDespesa).FirstOrDefaultAsync();

        if (despesa != null)
        {
            _dbContext.Despesas.Remove(despesa);

            return true;
        }

        return false;
    }
}
