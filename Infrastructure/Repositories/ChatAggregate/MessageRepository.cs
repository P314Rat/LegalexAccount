using Domain.Core.ChatAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure.Repositories.ChatAggregate
{
    public class MessageRepository : IRepository<Message, Guid>
    {
        private readonly ApplicationDbContext _dbContext;


        public MessageRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Message item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Message?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Message item)
        {
            throw new NotImplementedException();
        }
    }
}
