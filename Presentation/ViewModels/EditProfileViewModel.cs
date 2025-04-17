using System.ComponentModel.DataAnnotations;


namespace Presentation.ViewModels
{
    public class EditProfileViewModel
    {
        [Required(ErrorMessage = "Это необходимое поле")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string? LastName { get; set; }
        public string? SurName { get; set; }
        [Phone(ErrorMessage = "Неверный формат телефонного номера")]
        public string? PhoneNumber { get; set; }


        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }
        [DataType(DataType.Password)]
        public string? RepeatPassword { get; set; }
        public bool IsPasswordChangeRequested { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (IsPasswordChangeRequested)
            {
                if (string.IsNullOrWhiteSpace(OldPassword))
                    errors.Add(new ValidationResult("Введите текущий пароль", [nameof(OldPassword)]));

                if (string.IsNullOrWhiteSpace(NewPassword) || NewPassword.Length < 8 || NewPassword.Length > 32)
                    errors.Add(new ValidationResult("Пароль должен содержать от 8 до 32 символов", [nameof(NewPassword)]));

                if (NewPassword != RepeatPassword)
                    errors.Add(new ValidationResult("Пароли не совпадают.", [nameof(RepeatPassword)]));
            }

            return errors;
        }
    }
}
