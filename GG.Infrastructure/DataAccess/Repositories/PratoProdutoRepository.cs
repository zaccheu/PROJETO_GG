using GG.Domain.Entity;
using GG.Domain.Repositories.PratoProduto;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess.Repositories;

internal class PratoProdutoRepository : IPratoProdutoRepository
{
    private readonly GGDbContext _dbContext;
    public PratoProdutoRepository(GGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(PratoProduto produto) => await _dbContext.PratoProduto.AddAsync(produto);

    public async Task<List<PratoProduto>> GetAll() => await _dbContext.PratoProduto.AsNoTracking().ToListAsync();

    public async Task<bool> Delete(int idPedido)
    {
        PratoProduto? pedido = _dbContext.PratoProduto.Where(x => x.Prato.IdPrato == idPedido).FirstOrDefault();

        if (pedido != null)
        {
            _dbContext.PratoProduto.Remove(pedido);

            return true;
        }

        return false;
    }
}
