using System.ComponentModel.DataAnnotations;


namespace Presentation.ViewModels.EditProfile
{
    public class BankAccountViewModel
    {
        [Required(ErrorMessage = "Это необходимое поле")]
        public string BankAccountNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string BankName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string BankAddress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string BankIdenticationCode { get; set; } = string.Empty;
    }
}
