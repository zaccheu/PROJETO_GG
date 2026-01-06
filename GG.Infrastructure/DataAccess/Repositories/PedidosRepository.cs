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

    public async Task Add(Pedido expense) => await _dbContext.Pedidos.AddAsync(expense);

    public async Task<List<Pedido>> GetAll() => await _dbContext.Pedidos.AsNoTracking().ToListAsync();

    public async Task<bool> Delete(int idProduto)
    {
        Produto? produto = _dbContext.Produtos.Where(x => x.IdProduto == idProduto).FirstOrDefault();

        if (produto != null)
        {
            _dbContext.Produtos.Remove(produto);

            return true;
        }

        return false;
    }
}
