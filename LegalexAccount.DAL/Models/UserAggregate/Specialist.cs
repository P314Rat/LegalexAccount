using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.Utility.Types;


namespace LegalexAccount.DAL.Models.UserAggregate
{
    public class Specialist : User
    {
        public List<Case> Cases { get; set; }
        public SpecialistRole Role { get; set; }
        public SpecialistStatus Status { get; set; }
    }
}
