using Domain.Core;


namespace Infrastructure.Contracts
{
    public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        Task CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync(ISpecification<TEntity> specification);
        Task UpdateAsync(TEntity updatedEntity, ISpecification<TEntity> specification);
        Task DeleteAsync(ISpecification<TEntity> specification);
        Task<int> CountAsync(ISpecification<TEntity>? specification);
    }
}
