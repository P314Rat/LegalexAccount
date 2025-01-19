using LegalexAccount.Utility.Types;


namespace LegalexAccount.BLL.DTO
{
    public class IdentityDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserType UserType {  get; set; }
    }
}
