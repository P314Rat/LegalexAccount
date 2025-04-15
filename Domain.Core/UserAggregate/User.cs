using Domain.Core.CaseAggregate;
using Domain.Core.ChatAggregate;


namespace Domain.Core.UserAggregate
{
    public abstract class User : BaseEntity<Guid>
    {
        public required UserRole Role { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? SurName { get; set; }
        public string? PhoneNumber { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }
        public List<Case>? Cases { get; set; }
        public List<Chat>? Chats { get; set; }
    }
}
