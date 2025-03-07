using System.ComponentModel.DataAnnotations;


namespace Utilities.Types
{
    public enum UserRole
    {
        [Display(Name = "Технический специалист")]
        Technical = 0,
        [Display(Name = "Директор")]
        Director = 1,
        [Display(Name = "Специалист")]
        Employee = 2,
        [Display(Name = "Клиент")]
        Client = 3
    }
}
