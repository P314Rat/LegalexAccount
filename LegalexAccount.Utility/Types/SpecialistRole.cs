using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Utility.Types
{
    public enum SpecialistRole
    {
        [Display(Name = "Технический специалист")]
        Technical,
        [Display(Name = "Директор")]
        Director,
        [Display(Name = "Сотрудник")]
        Employee
    }
}
