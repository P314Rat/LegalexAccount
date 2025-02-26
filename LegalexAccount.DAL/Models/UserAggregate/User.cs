using LegalexAccount.DAL.Models.ChatAggregate;


namespace LegalexAccount.DAL.Models.UserAggregate
{
    public abstract class User : BaseEntity<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? SurName { get; set; } = null;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = null;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
    }
}
