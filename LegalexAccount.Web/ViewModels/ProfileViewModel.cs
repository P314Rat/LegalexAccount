using System.ComponentModel.DataAnnotations;

namespace LegalexAccount.Web.ViewModels
{
    public class ProfileViewModel
    {
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? SurName { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? PhoneNumber { get; set; } = null;
        [DataType(DataType.Password)]
        public string? OldPassword { get; set; } = null;

        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Пароль должен содержать минимум 8 символов.")]
        [MaxLength(32, ErrorMessage = "Пароль не должен превышать 32 символа.")]
        public string? NewPassword { get; set; } = null;

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают.")]
        public string? RepeatPassword { get; set; } = null;
    }
}
