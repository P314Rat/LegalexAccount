using Domain.Core.UserAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure.Repositories.UserAggregate
{
    public class SpecialistRepository : IUserRepository<Specialist, Guid>
    {
        private readonly ApplicationDbContext _dbContext;


        public SpecialistRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Specialist item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Specialist?> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Specialist?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Specialist>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Specialist item)
        {
            throw new NotImplementedException();
        }
    }
}
