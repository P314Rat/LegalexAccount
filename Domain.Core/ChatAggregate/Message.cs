namespace Domain.Core.ChatAggregate
{
    public class Message : BaseEntity<Guid>
    {
        public required string Text { get; set; }
        public required DateTime SendedAt { get; set; }
        public required string SenderEmail { get; set; }
        public required Chat Chat { get; set; }
    }
}
