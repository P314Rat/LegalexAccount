using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Utility.Types
{
    public enum SpecialistStatus
    {
        [Display(Name = "Свободен")]
        Free,
        [Display(Name = "Занят")]
        Busy
    }
}
