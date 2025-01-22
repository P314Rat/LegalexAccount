using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Utility.Types
{
    public enum SpecialistRole
    {
        [Display(Name = "Технический специалист")]
        Technical = 0,
        [Display(Name = "Директор")]
        Director = 1,
        [Display(Name = "Сотрудник")]
        Employee = 2
    }
}
