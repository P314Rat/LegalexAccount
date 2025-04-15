using System.ComponentModel.DataAnnotations;


namespace Utilities.Types
{
    public enum SpecialistRole
    {
        [Display(Name = "Специалист")]
        Specialist,
        [Display(Name = "Ведущий специалист")]
        LeadingSpecialist,
        [Display(Name = "Технический специалист")]
        TechnicalSpecialist,
        [Display(Name = "Директор")]
        Director
    }
}
