using Domain.Core.AccountAggregate;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class PasswordResetTokenRepository : IRepository<PasswordResetToken, int>
    {
        private readonly ApplicationDbContext _dbContext;


        public PasswordResetTokenRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<PasswordResetToken?> AsQueryable()
        {
            return _dbContext.PasswordResetTokens.AsQueryable();
        }

        public async Task CreateAsync(PasswordResetToken item)
        {
            await _dbContext.PasswordResetTokens.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PasswordResetToken?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(PasswordResetToken item)
        {
            var token = await _dbContext.PasswordResetTokens.FirstOrDefaultAsync(x => x.Id == item.Id);

            if (token == null)
                return;

            token.Token = item.Token;
            await _dbContext.SaveChangesAsync();
        }
    }
}
