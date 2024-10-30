namespace LegalexAccount.Web.ViewModels
{
    public class PersonViewModel : UserViewModel
    {
        public DateTime DateOfBirth { get; set; }                            // Дата рождения
        public string PassportNumber { get; set; } = string.Empty;           // Серия и номер документа удостоверяющего личность
        public string IssuingAuthority { get; set; } = string.Empty;         // Кем выдан
        public DateTime IssueDate { get; set; }                              // Дата выдачи
        public string TaxIdentificationNumber { get; set; } = string.Empty;  // Идентификационный номер (при наличии)
        public string RegistrationAddress { get; set; } = string.Empty;      // Адрес регистрации
        public string? ResidentialAddress { get; set; } = null;              // Адрес проживания (если отличается от адреса регистрации)
    }
}
