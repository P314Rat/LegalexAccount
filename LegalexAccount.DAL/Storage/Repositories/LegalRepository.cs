using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class LegalRepository : ILegalRepository
    {
        private const string REPOSITORY_NAME = "Legal";
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public LegalRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateAsync(Legal item)
        {
            var entry = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.LegalEntities?.AddAsync(item).AsTask();
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Legal was not created");
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

        public Task UpdateAsync(Legal item)
        {
            throw new NotImplementedException();
        }
    }
}
