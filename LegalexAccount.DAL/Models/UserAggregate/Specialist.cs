using LegalexAccount.Utility.Types;


namespace LegalexAccount.DAL.Models.UserAggregate
{
    public class Specialist : User
    {
        public SpecialistRole Role { get; set; }
        public SpecialistStatus Status { get; set; }
    }
}
