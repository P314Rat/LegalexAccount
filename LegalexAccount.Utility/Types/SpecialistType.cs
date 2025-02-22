using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Utility.Types
{
    public enum SpecialistType
    {
        [Display(Name = "Технический специалист")]
        Technical = 0,
        [Display(Name = "Директор")]
        Director = 1,
        [Display(Name = "Специалист")]
        Specialist = 2,
        [Display(Name = "Ведущий специалист")]
        LeadingSpecialist = 3
    }
}
