using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.CaseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public CaseRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateAsync(Case item)
        {
            var entry = await _dbContextFactory.CreateDbContext()?.Cases?.AddAsync(item).AsTask();

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Case was not created");
        }

        public async Task<Case> GetByIdAsync(int id)
        {
            var item = await _dbContextFactory.CreateDbContext()?.Cases?.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                throw new InvalidOperationException("Case was not found");

            return item;
        }

        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            var items = await _dbContextFactory.CreateDbContext()?.Cases.ToListAsync();

            if (items == null)
                throw new InvalidOperationException("Cases was not found");

            return items;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var dbContext = _dbContextFactory.CreateDbContext();

            var item = await dbContext?.Cases?.FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry<Case>? entry = null;

            if (item != null)
                entry = dbContext?.Cases?.Remove(item);

            if (entry == null || entry.State != EntityState.Deleted)
                throw new InvalidOperationException("Case was not deleted");
        }

        public async Task UpdateAsync(Case item)
        {
            throw new NotImplementedException();
        }
    }
}
