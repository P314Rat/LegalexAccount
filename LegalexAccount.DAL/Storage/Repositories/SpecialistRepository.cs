using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public SpecialistRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Task CreateAsync(Specialist item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Specialist>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Specialist> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Specialist item)
        {
            throw new NotImplementedException();
        }
    }
}
