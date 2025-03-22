using Domain.Core.ChatAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure.Repositories.ChatAggregate
{
    class ChatRepository : IRepository<Chat, Guid>
    {
        private readonly ApplicationDbContext _dbContext;


        public ChatRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Chat item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Chat?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Chat item)
        {
            throw new NotImplementedException();
        }
    }
}
