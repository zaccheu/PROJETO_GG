namespace GG.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
