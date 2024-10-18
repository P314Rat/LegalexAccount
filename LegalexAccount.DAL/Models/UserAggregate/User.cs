namespace LegalexAccount.DAL.Models.UserAggregate
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = null;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? SurName { get; set; } = null;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
    }
}
