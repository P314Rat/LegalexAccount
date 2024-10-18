namespace LegalexAccount.DAL.Models.OrderAggregate
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order item);
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(Order item);
    }
}
