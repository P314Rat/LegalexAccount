using Utilities.Types;


namespace Domain.Core.OrderAggregate
{
    public class Order : BaseEntity<int>
    {
        public required DateTime CreatedAt { get; set; }
        public required ClientType ClientType { get; set; }
        public required ServiceType Service { get; set; }
        public required string Name { get; set; }
        public required string Contact { get; set; }
        public required string Description { get; set; }
    }
}
