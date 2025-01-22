using LegalexAccount.DAL.Models;


namespace LegalexAccount.DAL.Repositories.Contracts
{
    public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        Task CreateAsync(TEntity item);
        Task<TEntity?> GetByIdAsync(TId id);
        Task UpdateAsync(TEntity item);
        Task DeleteByIdAsync(TId id);
        IQueryable<TEntity?> AsQueryable();
    }
}
