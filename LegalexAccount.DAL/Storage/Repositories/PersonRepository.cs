using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private const string REPOSITORY_NAME = "Person";
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public PersonRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateAsync(Person item)
        {
            var entry = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.Individuals?.AddAsync(item).AsTask();
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Person was not created");
        }

        public async Task DeleteByEmailAsync(string email)
        {
            var dbContext = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);
            var item = await dbContext?.Individuals?.FirstOrDefaultAsync(x => x.Email == email);

            EntityEntry<Person>? entry = null;

            if (item != null)
                entry = dbContext?.Individuals?.Remove(item);

            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (entry == null || entry.State != EntityState.Deleted)
                throw new InvalidOperationException("Person was not deleted");
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var items = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.Individuals.ToListAsync();
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (items == null)
                throw new InvalidOperationException("Individuals was not found");

            return items;
        }

        public async Task<Person> GetByEmailAsync(string email)
        {
            var item = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.Individuals?.FirstOrDefaultAsync(x => x.Email == email);
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (item == null)
                throw new InvalidOperationException("Person was not found");

            return item;
        }

        public Task UpdateAsync(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
