using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Repositories
{
    public class SpecialistRepository : IRepository<Specialist, Guid>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public SpecialistRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Specialist?> AsQueryable()
        {
            return _dbContext.Specialists.AsQueryable();
        }

        public async Task CreateAsync(Specialist item)
        {
            var entry = await _dbContext.Specialists.AddAsync(item);

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Specialist was not created");

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var item = await _dbContext.Specialists.FirstOrDefaultAsync(x => x.Id == id);

            if (item != null)
            {
                var entry = _dbContext.Specialists.Remove(item);

                if (entry == null || entry.State != EntityState.Added)
                    throw new InvalidOperationException("Specialist was not created");
            }
            else
                throw new NullReferenceException("Specialist is not exists");

            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var specialist = await _dbContext.Specialists.FirstOrDefaultAsync(x => x.Email == email);

            return specialist;
        }

        public Task<Specialist?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Specialist item)
        {
            throw new NotImplementedException();
        }
    }
}
