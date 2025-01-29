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

        public async Task UpdateAsync(Client item)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == item.Id);

            if (client == null)
                return;

            client.Email = item.Email;
            client.FirstName = item.FirstName;
            client.LastName = item.LastName;
            client.SurName = item.SurName;
            client.PhoneNumber = item.PhoneNumber;

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Client?> AsQueryable()
        {
            return _dbContext.Clients.AsQueryable();
        }

        public Task<User> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
