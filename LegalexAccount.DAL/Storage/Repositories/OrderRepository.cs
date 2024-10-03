using LegalexAccount.DAL.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order GetById(int id)
        {
            var item = _dbContext?.Orders?.FirstOrDefault(x => x.Id == id);

            if (item == null)
                throw new InvalidOperationException("Order was not found");

            return item;
        }

        public IEnumerable<Order> GetAll()
        {
            var items = _dbContext?.Orders.ToList();

            if (items == null)
                throw new InvalidOperationException("Orders was not found");

            return items;
        }

        public void DeleteById(int id)
        {
            var item = _dbContext?.Orders?.FirstOrDefault(x => x.Id == id);
            EntityEntry<Order>? entry = null;

            if (item != null)
                entry = _dbContext?.Orders?.Remove(item);

            if (entry == null || entry.State != EntityState.Deleted)
                throw new InvalidOperationException("Order was not found");
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
