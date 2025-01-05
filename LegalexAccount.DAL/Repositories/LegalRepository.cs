using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LegalexAccount.DAL.Repositories
{
    public class LegalRepository : IRepository<Legal, Guid>
    {
        private const string REPOSITORY_NAME = "Legal";
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public LegalRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IQueryable<Legal> AsQueryable()
        {
            return _dbContextFactory.CreateDbContext(REPOSITORY_NAME).LegalEntities.AsQueryable();
        }

        public async Task CreateAsync(Legal item)
        {
            var entry = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.LegalEntities?.AddAsync(item).AsTask();

            if (entry == null || entry.State != EntityState.Added)
            {
                _dbContextFactory.Dispose(REPOSITORY_NAME);
                throw new InvalidOperationException("Legal was not created");
            }

            _dbContextFactory.Dispose(REPOSITORY_NAME);

        }

        public async Task DeleteByEmailAsync(string email)
        {
            var dbContext = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);
            var item = await dbContext?.LegalEntities?.FirstOrDefaultAsync(x => x.Email == email);

            EntityEntry<Legal>? entry = null;

            if (item != null)
                entry = dbContext?.LegalEntities?.Remove(item);

            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (entry == null || entry.State != EntityState.Deleted)
                throw new InvalidOperationException("Legal was not deleted");
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Legal>> GetAllAsync()
        {
            var items = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.LegalEntities.ToListAsync();
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (items == null)
                throw new InvalidOperationException("Legals was not found");

            return items;
        }

        public async Task<Legal> GetByEmailAsync(string email)
        {
            var item = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.LegalEntities?.FirstOrDefaultAsync(x => x.Email == email);
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (item == null)
                throw new InvalidOperationException("Legal was not found");

            return item;
        }

        public Task<Legal> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Legal item)
        {
            throw new NotImplementedException();
        }
    }
}
