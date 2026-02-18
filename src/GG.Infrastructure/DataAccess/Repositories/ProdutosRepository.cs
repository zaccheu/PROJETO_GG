using GG.Domain.Entity;
using GG.Domain.Repositories.Produtos;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess.Repositories;

internal class ProdutosRepository : IProdutoRepository
{
    private readonly GGDbContext _dbContext;
    public ProdutosRepository(GGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Produto produto) => await _dbContext.Produtos.AddAsync(produto);
    
    public async Task<List<Produto>> GetAll() => await _dbContext.Produtos.ToListAsync();
    
    public async Task<bool> Delete(int idProduto)
    {
        Produto? produto = _dbContext.Produtos.Where(x => x.Id == idProduto).FirstOrDefault();

        if (produto != null)
        {
            _dbContext.Produtos.Remove(produto);

            return true;
        }

        return false;
    }
}
