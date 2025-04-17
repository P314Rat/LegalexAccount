using System.ComponentModel.DataAnnotations;


namespace Utilities.Types
{
    public enum UserRole
    {
        [Display(Name = "Специалист")]
        Specialist,
        [Display(Name = "Клиент")]
        Client
    }
}
