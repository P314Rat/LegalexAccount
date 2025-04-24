using System.ComponentModel.DataAnnotations;


namespace Presentation.ViewModels.EditProfile
{
    public class DocumentsViewModel
    {
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Это необходимое поле")]
        public string PassportNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string IssuingAuthority { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public string? TaxIdentificationNumber { get; set; }
        [Required(ErrorMessage = "Это необходимое поле")]
        public string RegistrationAddress { get; set; } = string.Empty;
        public string? ResidentialAddress { get; set; }
    }
}
