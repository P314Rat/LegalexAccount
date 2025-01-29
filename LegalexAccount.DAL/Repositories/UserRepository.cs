using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Repositories
{
    public class UserRepository : IRepository<User, Guid>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<User> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var specialist = await _dbContext.Specialists.FirstOrDefaultAsync(x => x.Email == email);

            if (specialist == null)
            {
                var client = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Email == email);

                return client;
            }

            return specialist;
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExistsAsync(string email)
        {
            bool isUserExists = false;

            isUserExists = await _dbContext.Specialists.AnyAsync(x => x.Email == email);

            if (isUserExists)
                isUserExists = await _dbContext.Clients.AnyAsync(x => x.Email == email);

            return isUserExists;
        }

        public async Task UpdateAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
