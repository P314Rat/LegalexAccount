using Domain.Core.AccountAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure.Repositories.AccountAggregate
{
    public class PasswordResetTokenRepository : IRepository<PasswordResetToken, int>
    {
        private readonly ApplicationDbContext _dbContext;


        public PasswordResetTokenRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(PasswordResetToken item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PasswordResetToken?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PasswordResetToken>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PasswordResetToken item)
        {
            throw new NotImplementedException();
        }
    }
}
