using Domain.Core.UserAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure.Repositories.UserAggregate
{
    public class LegalRepository : IUserRepository<Legal, Guid>
    {
        private readonly ApplicationDbContext _dbContext;


        public LegalRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Legal item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Legal?> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Legal?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Legal>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Legal item)
        {
            throw new NotImplementedException();
        }
    }
}
