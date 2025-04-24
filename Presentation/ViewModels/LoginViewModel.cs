using System.ComponentModel.DataAnnotations;


namespace Presentation.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Это необходимое поле")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Это необходимое поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
