namespace LegalexAccount.BLL.DTO
{
    public class PersonDTO : UserDTO
    {
        public DateTime? DateOfBirth { get; set; } = null;                            // Дата рождения
        public string? PassportNumber { get; set; } = null;          // Серия и номер документа удостоверяющего личность
        public string? IssuingAuthority { get; set; } = null;         // Кем выдан
        public DateTime? IssueDate { get; set; } = null;                              // Дата выдачи
        public string? TaxIdentificationNumber { get; set; } = null;  // Идентификационный номер (при наличии)
        public string? RegistrationAddress { get; set; } = null;             // Адрес регистрации
        public string? ResidentialAddress { get; set; } = null;              // Адрес проживания (если отличается от адреса регистрации)
    }
}
