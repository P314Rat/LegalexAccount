using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Web.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите новый пароль")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают.")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }
}
