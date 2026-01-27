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

    public async Task<bool> Delete(int idDespesa)
    {
        Despesa? despesa = _dbContext.Despesas.Where(x => x.IdDespesa == idDespesa).FirstOrDefault();

        if (despesa != null)
        {
            _dbContext.Despesas.Remove(despesa);

            return true;
        }

        return false;
    }
}
