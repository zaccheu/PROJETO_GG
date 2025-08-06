using GG.Domain.Entity;
using GG.Domain.Repositories.Pedidos;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess.Repositories;

internal class PedidosRepository : IPedidosRepository
{
    private readonly GGDbContext _dbContext;
    public PedidosRepository(GGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Pedido expense)
    {
        await _dbContext.Pedidos.AddAsync(expense);
    }

    public async Task<List<Pedido>> GetAll()
    {
        return await _dbContext.Pedidos.ToListAsync();
    }
}
