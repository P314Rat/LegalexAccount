using Domain.Core.CaseAggregate;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
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
            await _dbContext.Cases.AddAsync(item).AsTask();

            _dbContext.SaveChanges();
        }

        public async Task<Case?> GetByIdAsync(int id)
        {
            var result = await _dbContext.Cases.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var item = await _dbContext.Cases.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return;

            _dbContext.Cases.Remove(item);
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
