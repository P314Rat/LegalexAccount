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

        public Task<User> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Specialist item)
        {
            var specialist = await _dbContext.Specialists.FirstOrDefaultAsync(x => x.Email == item.Email);

            if (specialist == null)
                return;

            specialist.Email = item.Email;
            specialist.FirstName = item.FirstName;
            specialist.LastName = item.LastName;
            specialist.SurName = item.SurName;
            specialist.PhoneNumber = item.PhoneNumber;

            await _dbContext.SaveChangesAsync();
        }
    }
}
