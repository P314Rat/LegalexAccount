using Domain.Core.UserAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure.Repositories.UserAggregate
{
    public class UserRepository : IUserRepository<User, Guid>
    {
        private readonly ApplicationDbContext _dbContext;


        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
