using Domain.Core.UserAggregate;


namespace Domain.Core.OrderAggregate
{
    public class Order : BaseEntity<int>
    {
        public required DateTime CreatedAt { get; set; }
        public required ClientRole ClientType { get; set; }
        public required Utilities.Types.ServiceType Service { get; set; }
        public required string ClientName { get; set; }
        public required string Contact { get; set; }
        public required string Description { get; set; }
    }
}
