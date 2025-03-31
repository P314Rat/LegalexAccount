using System.ComponentModel.DataAnnotations;


namespace Presentation.ViewModels
{
    public class EditProfileViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Пароль должен содержать минимум 8 символов.")]
        [MaxLength(32, ErrorMessage = "Пароль не должен превышать 32 символа.")]
        public string NewPassword { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают.")]
        public string RepeatPassword { get; set; } = string.Empty;
    }
}
