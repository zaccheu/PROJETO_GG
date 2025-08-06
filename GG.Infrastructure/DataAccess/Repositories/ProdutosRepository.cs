using GG.Domain.Entity;
using GG.Domain.Repositories.Produtos;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess.Repositories;

internal class ProdutosRepository : IProdutosRepository
{
    private readonly GGDbContext _dbContext;
    public ProdutosRepository(GGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Produto produto)
    {
        await _dbContext.Produtos.AddAsync(produto);
    }

    public async Task<List<Produto>> GetAll()
    {
        return await _dbContext.Produtos.ToListAsync();
    }
}
