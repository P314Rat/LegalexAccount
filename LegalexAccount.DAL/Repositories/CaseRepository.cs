using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LegalexAccount.DAL.Repositories
{
    public class CaseRepository : IRepository<Case, int>
    {
        private const string REPOSITORY_NAME = "Case";
        private readonly IApplicationDbContextFactory _dbContextFactory;
        private readonly ApplicationDbContext _dbContext;


        public CaseRepository(ApplicationDbContext dbContext, IApplicationDbContextFactory dbContextFactory)
        {
            _dbContext = dbContext;
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateAsync(Case item)
        {
            var entry = await _dbContext.Cases.AddAsync(item).AsTask();

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Case was not created");

            _dbContext.SaveChanges();
        }

        public async Task<Case> GetByIdAsync(int id)
        {
            var item = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.Cases?.FirstOrDefaultAsync(x => x.Id == id);
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (item == null)
                throw new InvalidOperationException("Case was not found");

            return item;
        }

        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            var items = await _dbContextFactory.CreateDbContext(REPOSITORY_NAME)?.Cases.ToListAsync();
            _dbContextFactory.Dispose(REPOSITORY_NAME);

            if (items == null)
                throw new InvalidOperationException("Cases was not found");

            return items;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var dbContext = _dbContextFactory.CreateDbContext(REPOSITORY_NAME);
            _dbContextFactory.Dispose(REPOSITORY_NAME);

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

        public IQueryable<Case> AsQueryable()
        {
            var query = _dbContext.Cases.AsQueryable();

            return query;
        }
    }
}
