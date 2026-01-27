using GG.Domain.Entity;
using GG.Domain.Repositories.Pedidos;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess.Repositories;

internal class PedidosRepository : IPedidoRepository
{
    private readonly GGDbContext _dbContext;
    
    public PedidosRepository(GGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Pedido pedido) => await _dbContext.Pedidos.AddAsync(pedido);

    public async Task<List<Pedido>> GetAll() => 
        await _dbContext.Pedidos
            .AsNoTracking()
            .Include(p => p.PedidoPratos)
            .ThenInclude(pp => pp.Prato)
            .ToListAsync();

    public async Task<Pedido?> GetById(int idPedido) =>
        await _dbContext.Pedidos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.IdPedido == idPedido);

    public async Task<Pedido?> GetByIdWithDetails(int idPedido) =>
        await _dbContext.Pedidos
            .AsNoTracking()
            .Include(p => p.PedidoPratos)
            .ThenInclude(pp => pp.Prato)
            .Include(p => p.Cliente)
            .FirstOrDefaultAsync(p => p.IdPedido == idPedido);

    public void Update(Pedido pedido) => _dbContext.Pedidos.Update(pedido);

    public async Task<bool> Delete(int idPedido)
    {
        var pedido = await _dbContext.Pedidos
            .FirstOrDefaultAsync(x => x.IdPedido == idPedido);

        if (pedido != null)
        {
            _dbContext.Pedidos.Remove(pedido);
            return true;
        }

        return false;
    }
}
