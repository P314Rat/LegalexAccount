using Domain.Core.ChatAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure.Repositories
{
    public class MessageRepository : IRepository<Message, Guid>
    {
        private readonly ApplicationDbContext _dbContext;


        public MessageRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Message?> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Message item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Message?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Message item)
        {
            throw new NotImplementedException();
        }
    }
}
