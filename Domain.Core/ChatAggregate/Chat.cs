using Domain.Core.UserAggregate;


namespace Domain.Core.ChatAggregate
{
    public class Chat : BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public required List<User> Members { get; set; }
        public List<Message>? Messages { get; set; }
    }
}
