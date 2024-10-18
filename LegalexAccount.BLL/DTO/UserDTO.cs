using LegalexAccount.Utility.Types;


namespace LegalexAccount.BLL.DTO
{
    public enum UserType
    {
        Specialist,
        Person,
        Legal
    }

    public class UserDTO
    {
        public UserType UserType { get; set; }
        public ClientType ClientType { get; set; }
        public string? Email { get; set; } = null;
        public string? Phone { get; set; } = null;
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? SurName { get; set; } = null;
        public string? Password { get; set; } = null;

    }
}
