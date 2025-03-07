namespace Domain.Core.ChatAggregate
{
    public class Message : BaseEntity<Guid>
    {
        public required Guid SenderId { get; set; }
        public required string Text { get; set; }
        public required DateTime SendedAt { get; set; }
    }
}
