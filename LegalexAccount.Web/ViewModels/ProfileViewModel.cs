using LegalexAccount.Utility.Types;


namespace LegalexAccount.Web.ViewModels
{
    public class ProfileViewModel
    {
        public string? OrganizationName { get; set; } = null;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserType UserType { get; set; }
    }
}
