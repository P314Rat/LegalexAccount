namespace LegalexAccount.DAL.Models.ChatAggregate
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Message> Messages { get; set; } = new();
    }
}
