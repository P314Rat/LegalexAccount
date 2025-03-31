using Domain.Core.OrderAggregate;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories.OrderAggregate
{
    public class OrderRepository : IRepository<Order, int>
    {
        private readonly ApplicationDbContext _dbContext;


        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAsync()
        {
            var result =  await _dbContext.Orders.ToListAsync();

            return result;
        }

        public Task UpdateAsync(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
