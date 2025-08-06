using GG.Domain.Repositories;

namespace GG.Infrastructure.DataAccess;
internal class UnitOfWork : IUnitOfWork
{
    private readonly GGDbContext _dbContext;
    public UnitOfWork(GGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
