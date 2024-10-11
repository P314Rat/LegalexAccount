using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.Web.ViewModels
{
    public class SpecialistViewModel : UserViewModel
    {
        public SpecialistStatus Status { get; set; }
        public SpecialistRole Role { get; set; }
    }
}
