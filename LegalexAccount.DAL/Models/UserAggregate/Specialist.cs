using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.DAL.Models.UserAggregate
{
    public enum SpecialistStatus
    {
        [Display(Name = "Свободен")]
        Free,
        [Display(Name = "Занят")]
        Busy
    }

    public class Specialist : User
    {
        public SpecialistStatus Status { get; set; }
    }
}
