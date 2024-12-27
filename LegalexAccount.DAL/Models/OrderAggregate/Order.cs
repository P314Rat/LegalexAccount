using LegalexAccount.Utility.Types;


namespace LegalexAccount.DAL.Models.OrderAggregate
{
    public class Order : BaseEntity<int>
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ClientType ClientType { get; set; }
        public ServiceType Service { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
