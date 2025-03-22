using Domain.Core;


namespace Infrastructure.Repositories.Contracts
{
    public interface IUserRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        Task<TEntity?> GetAsync(string email);
    }
}
