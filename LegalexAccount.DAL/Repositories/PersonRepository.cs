using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Repositories
{
    public class PersonRepository : IRepository<Person, Guid>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public PersonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Person> AsQueryable()
        {
            return _dbContext.Individuals.AsQueryable();
        }

        public async Task CreateAsync(Person item)
        {
            var entry = await _dbContext.Individuals.AddAsync(item);

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Person was not created");

            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Person?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
