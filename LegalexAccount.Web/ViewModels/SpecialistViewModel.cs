using LegalexAccount.Utility.Types;


namespace LegalexAccount.Web.ViewModels
{
    public class SpecialistViewModel : UserViewModel
    {
        public SpecialistStatus Status { get; set; }
        public SpecialistType Role { get; set; }
    }
}
