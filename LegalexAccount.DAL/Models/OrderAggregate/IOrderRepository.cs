namespace LegalexAccount.DAL.Models.OrderAggregate
{
    public interface IOrderRepository
    {
        Order GetById(int id);
        IEnumerable<Order> GetAll();
        void DeleteById(int id);
        void Update(Order item);
    }
}
