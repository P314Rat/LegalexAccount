using Domain.Core.OrderAggregate;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class OrderRepository : IRepository<Order, int>
    {
        private readonly ApplicationDbContext _dbContext;


        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Order item)
        {
            var entry = await _dbContext.Orders.AddAsync(item);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var item = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var item = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return;

            _dbContext.Orders.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order?> AsQueryable()
        {
            return _dbContext.Orders.AsQueryable();
        }
    }
}
