using Domain.Core;
using Infrastructure.Contracts;


public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity, TId> Repository<TEntity, TId>() where TEntity : BaseEntity<TId>;
    Task<int> SaveChangesAsync();
}
