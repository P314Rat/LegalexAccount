using Domain.Core.UserAggregate;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class SpecialistRepository : IRepository<Specialist, Guid>, IUserRepository<Specialist>
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
            await _dbContext.Specialists.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var item = await _dbContext.Specialists.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return;

            _dbContext.Specialists.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Specialist?> GetByEmailAsync(string email)
        {
            var specialist = await _dbContext.Specialists.FirstOrDefaultAsync(x => x.Email == email);

            return specialist;
        }

        public Task<Specialist?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExistsAsync(string email)
        {
            var result = await _dbContext.Specialists.AnyAsync(x => x.Email == email);

            return result;
        }

        public async Task UpdateAsync(Specialist item)
        {
            var specialist = await _dbContext.Specialists.FirstOrDefaultAsync(x => x.Id == item.Id);

            if (specialist == null)
                return;

            specialist.Email = item.Email;
            specialist.FirstName = item.FirstName;
            specialist.LastName = item.LastName;
            specialist.SurName = item.SurName;
            specialist.PhoneNumber = item.PhoneNumber;

            if (item.PasswordHash != string.Empty)
            {
                specialist.PasswordHash = item.PasswordHash;
                specialist.PasswordSalt = item.PasswordSalt;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
