using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Models.ChatAggregate
{
    public class Chat : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public List<User> Members { get; set; }
        public List<Message> Messages { get; set; }
    }
}
