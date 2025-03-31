using Domain.Core.UserAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure.Repositories.UserAggregate
{
    public class ClientRepository : IUserRepository<Client, Guid>
    {
        private readonly ApplicationDbContext _dbContext;


        public ClientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Client item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Client?> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Client?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Client item)
        {
            throw new NotImplementedException();
        }
    }
}
