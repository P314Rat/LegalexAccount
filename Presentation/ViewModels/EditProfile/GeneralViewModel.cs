using System.ComponentModel.DataAnnotations;


namespace Presentation.ViewModels.EditProfile
{
    public class GeneralViewModel
    {
        [Required(ErrorMessage = "Это необходимое поле")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string LastName { get; set; } = string.Empty;
        public string? SurName { get; set; }
        [Phone(ErrorMessage = "Неверный формат телефонного номера")]
        public string? PhoneNumber { get; set; }
    }
}
