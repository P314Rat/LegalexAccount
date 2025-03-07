using System.ComponentModel.DataAnnotations;


namespace Utilities.Types
{
    public enum SpecialistStatus
    {
        [Display(Name = "Свободен")]
        Free,
        [Display(Name = "Занят")]
        Busy
    }
}
