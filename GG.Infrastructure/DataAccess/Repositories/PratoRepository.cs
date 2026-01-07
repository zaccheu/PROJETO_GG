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

    public async Task Add(Prato produto) => await _dbContext.Prato.AddAsync(produto);

    public async Task<List<Prato>> GetAll() => await _dbContext.Prato.AsNoTracking().ToListAsync();

    public async Task<bool> Delete(int idPedido)
    {
        Prato? pedido = _dbContext.Prato.Where(x => x.IdPrato == idPedido).FirstOrDefault();

        if (pedido != null)
        {
            _dbContext.Prato.Remove(pedido);

            return true;
        }

        return false;
    }
}
