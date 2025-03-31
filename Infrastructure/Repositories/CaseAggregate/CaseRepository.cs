using Domain.Core.CaseAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure.Repositories.CaseAggregate
{
    public class CaseRepository : IRepository<Case, int>
    {
        private readonly ApplicationDbContext _dbContext;


        public CaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Case item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Case?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Case>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Case item)
        {
            throw new NotImplementedException();
        }
    }
}
