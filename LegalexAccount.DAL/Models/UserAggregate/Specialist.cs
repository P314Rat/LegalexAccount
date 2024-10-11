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

    public enum SpecialistRole
    {
        [Display(Name = "Технический специалист")]
        Technical,
        [Display(Name = "Директор")]
        Director,
        [Display(Name = "Сотрудник")]
        Employee
    }

    public class Specialist : User
    {
        public SpecialistStatus Status { get; set; }
        public SpecialistRole Role { get; set; }
    }
}
