using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Repositories
{
    public class CaseRepository : IRepository<Case, int>
    {
        private readonly ApplicationDbContext _dbContext;


        public CaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Case item)
        {
            var entry = await _dbContext.Cases.AddAsync(item).AsTask();

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Case was not created");

            _dbContext.SaveChanges();
        }

        public async Task<Case?> GetByIdAsync(int id)
        {
            var item = await _dbContext.Cases.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                throw new InvalidOperationException("Case was not found");

            return item;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var item = await _dbContext.Cases.FirstOrDefaultAsync(x => x.Id == id);

            if (item != null)
            {
                var entry = _dbContext.Cases.Remove(item);

                if (entry == null || entry.State != EntityState.Deleted)
                    throw new InvalidOperationException("Case was not deleted");
            }
            else
                throw new NullReferenceException("Case is not exists");

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Case?> AsQueryable()
        {
            return _dbContext.Cases.AsQueryable();
        }

        public Task UpdateAsync(Case item)
        {
            throw new NotImplementedException();
        }
    }
}
