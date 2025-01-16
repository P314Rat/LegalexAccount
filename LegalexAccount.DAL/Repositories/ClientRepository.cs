using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Repositories
{
    public class ClientRepository : IRepository<Client, Guid>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public ClientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Client?> GetByEmailAsync(string email)
        {
            var client = await _dbContext.Clients.Where(x => x.Email == email).FirstOrDefaultAsync();

            return client;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var clients = await _dbContext.Clients.ToListAsync();

            return clients;
        }

        public Task CreateAsync(Client item)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Client item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Client?> AsQueryable()
        {
            var query = _dbContext.Clients.AsQueryable();

            return query;
        }

        public Task<User> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
