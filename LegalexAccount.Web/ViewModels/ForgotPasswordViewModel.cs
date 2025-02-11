using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Web.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Это необходимое поле")]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; } = string.Empty;
    }
}
