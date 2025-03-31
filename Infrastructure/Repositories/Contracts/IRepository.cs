using Domain.Core;


namespace Infrastructure.Repositories.Contracts
{
    public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        Task CreateAsync(TEntity item);
        Task<List<TEntity>> GetAsync();
        Task<TEntity?> GetAsync(TId id);
        Task UpdateAsync(TEntity item);
        Task DeleteAsync(TId id);
    }
}
