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

        public IQueryable<Specialist> AsQueryable()
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

        public async Task DeleteByIdAsync(string email)
        {
            var item = await _dbContext.Specialists.FirstOrDefaultAsync(x => x.Email == email);

            if (item != null)
                _dbContext?.Specialists?.Remove(item);
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Specialist>> GetAllAsync()
        {
            var items = await _dbContext.Specialists.ToListAsync();

            return items;
        }

        public async Task<Specialist?> GetByEmailAsync(string email)
        {
            var item = await _dbContext.Specialists.FirstOrDefaultAsync(x => x.Email == email);

            return item;
        }

        public Task<Specialist> GetByIdAsync(Guid id)
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

        public Task UpdateAsync(Specialist item)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
