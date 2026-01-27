using GG.Domain.Entity;
using GG.Domain.Repositories.PedidoPrato;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess.Repositories;

internal class PedidoPratoRepository : IPedidoPratoRepository
{
    private readonly GGDbContext _dbContext;
    public PedidoPratoRepository(GGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(PedidoPrato produto) => await _dbContext.PedidoPrato.AddAsync(produto);

    public async Task<List<PedidoPrato>> GetAll() => await _dbContext.PedidoPrato.AsNoTracking().ToListAsync();

    public async Task<bool> Delete(int idPedido)
    {
        PedidoPrato? pedido = _dbContext.PedidoPrato.Where(x => x.Pedido.IdPedido == idPedido).FirstOrDefault();

        if (pedido != null)
        {
            _dbContext.PedidoPrato.Remove(pedido);

            return true;
        }

        return false;
    }
}
