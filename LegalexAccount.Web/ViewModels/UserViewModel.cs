using System.ComponentModel.DataAnnotations;

namespace LegalexAccount.Web.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Это необходимое поле")]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = null;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string LastName { get; set; } = string.Empty;
        public string? SurName { get; set; } = null;
        [Required(ErrorMessage = "Это необходимое поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
