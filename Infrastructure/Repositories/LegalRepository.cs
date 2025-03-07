using Domain.Core.UserAggregate;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class LegalRepository : IRepository<Legal, Guid>, IUserRepository<Legal>
    {
        private readonly ApplicationDbContext _dbContext;


        public LegalRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Legal?> AsQueryable()
        {
            return _dbContext.LegalEntities.AsQueryable();
        }

        public async Task CreateAsync(Legal item)
        {
            var entry = await _dbContext.LegalEntities.AddAsync(item);

            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Legal?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Legal> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Legal item)
        {
            throw new NotImplementedException();
        }
    }
}
