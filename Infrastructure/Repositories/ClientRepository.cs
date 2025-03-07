using Domain.Core.UserAggregate;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class ClientRepository : IRepository<Client, Guid>, IUserRepository<Client>
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

        public Task<bool> IsExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Client?> GetByEmailAsync(string email)
        {
            var legal = await _dbContext.LegalEntities.FirstOrDefaultAsync(x => x.Email == email);

            if (legal != null)
                return legal;

            var person = await _dbContext.Individuals.FirstOrDefaultAsync(x => x.Email == email);

            return person;
        }
    }
}
