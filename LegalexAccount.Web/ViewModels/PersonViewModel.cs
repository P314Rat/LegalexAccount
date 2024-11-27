using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Web.ViewModels
{
    public class PersonViewModel : UserViewModel
    {
        public DateTime DateOfBirth { get; set; } = DateTime.Now;            // Дата рождения
        [Required(ErrorMessage = "Это необходимое поле")]
        public string PassportNumber { get; set; } = string.Empty;           // Серия и номер документа удостоверяющего личность
        [Required(ErrorMessage = "Это необходимое поле")]
        public string IssuingAuthority { get; set; } = string.Empty;         // Кем выдан
        public DateTime IssueDate { get; set; } = DateTime.Now;              // Дата выдачи
        public string? TaxIdentificationNumber { get; set; }                 // Идентификационный номер (при наличии)
        [Required(ErrorMessage = "Это необходимое поле")]
        public string RegistrationAddress { get; set; } = string.Empty;      // Адрес регистрации
        public string? ResidentialAddress { get; set; } = null;              // Адрес проживания (если отличается от адреса регистрации)
    }
}
