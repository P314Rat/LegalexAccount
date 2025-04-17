using Domain.Core;
using Infrastructure;
using Infrastructure.Contracts;


public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private readonly Dictionary<string, object> _repositories;


    public UnitOfWork(ApplicationDbContext context)
    {
        _dbContext = context;
        _repositories = new();
    }

    public IRepository<TEntity, TId> Repository<TEntity, TId>() where TEntity : BaseEntity<TId>
    {
        var typeName = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(typeName))
        {
            var repositoryInstance = new Repository<TEntity, TId>(_dbContext);
            _repositories[typeName] = repositoryInstance;
        }

        return (IRepository<TEntity, TId>)_repositories[typeName];
    }

    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
