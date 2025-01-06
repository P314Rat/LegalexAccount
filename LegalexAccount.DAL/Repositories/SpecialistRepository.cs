using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LegalexAccount.DAL.Repositories
{
    public class SpecialistRepository : IRepository<Specialist, Guid>, IUserRepository
    {
        private const string REPOSITORY_NAME = "Specialist";
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public SpecialistRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IQueryable<Specialist> AsQueryable()
        {
            return _dbContextFactory.CreateDbContext(REPOSITORY_NAME).Specialists.AsQueryable();
        }

        public async Task CreateAsync(Specialist item)
        {
            var entry = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.Specialists?.AddAsync(item).AsTask();
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (entry == null || entry.State != EntityState.Added)
            {
                _dbContextFactory.Dispose(REPOSITORY_NAME);
                throw new InvalidOperationException("Specialist was not created");
            }

            _dbContextFactory.Dispose(REPOSITORY_NAME);
        }

        public async Task DeleteByIdAsync(string email)
        {
            var dbContext = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);
            var item = await dbContext?.Specialists?.FirstOrDefaultAsync(x => x.Email == email);

            EntityEntry<Specialist>? entry = null;

            if (item != null)
                entry = dbContext?.Specialists?.Remove(item);

            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (entry == null || entry.State != EntityState.Deleted)
                throw new InvalidOperationException("Specialist was not deleted");
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Specialist>> GetAllAsync()
        {
            var items = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.Specialists.ToListAsync();
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (items == null)
                throw new InvalidOperationException("Specialists was not found");

            return items;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var qe = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);
            var item = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.Specialists?.FirstOrDefaultAsync(x => x.Email == email);
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (item == null)
                throw new InvalidOperationException("Specialist was not found");

            return item;
        }

        public Task<Specialist> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Specialist item)
        {
            throw new NotImplementedException();
        }
    }
}
