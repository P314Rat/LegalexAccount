using LegalexAccount.Utility.Types;

namespace LegalexAccount.BLL.DTO
{
    public class ProfileDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
    }
}
