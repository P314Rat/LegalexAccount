using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public OrderRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateAsync(Order item)
        {
            var entry = await _dbContextFactory.CreateDbContext()?.Orders?.AddAsync(item).AsTask();

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Order was not created");
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var item = await _dbContextFactory.CreateDbContext().Orders.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (item == null)
                throw new InvalidOperationException("Order was not found");

            return item;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var items = await _dbContextFactory.CreateDbContext()?.Orders.ToListAsync();

            if (!items.Any())
                throw new InvalidOperationException("Orders was not found");

            return items;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var dbContext = _dbContextFactory.CreateDbContext();
            var item = await dbContext?.Orders?.FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry<Order>? entry = null;

            if (item != null)
                entry = dbContext?.Orders?.Remove(item);

            if (entry == null || entry.State != EntityState.Deleted)
                throw new InvalidOperationException("Order was not deleted");
        }

        public Task UpdateAsync(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
