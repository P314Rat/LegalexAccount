namespace LegalexAccount.DAL.Models.ChatAggregate
{
    public class Message : BaseEntity<Guid>
    {
        public Guid ChatId { get; set; }
        public Guid SenderId { get; set; }
        public string Text { get; set; }
        public DateTime SendedAt { get; set; }
        public Chat Chat { get; set; }
    }
}
