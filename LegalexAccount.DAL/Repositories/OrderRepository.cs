using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL.Repositories
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

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Order was not created");

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

            if (item != null)
            {
                var entry = _dbContext.Orders.Remove(item);

                if (entry == null || entry.State != EntityState.Deleted)
                    throw new InvalidOperationException("Order was not deleted");
            }
            else
                throw new NullReferenceException("Order is not exists");

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
