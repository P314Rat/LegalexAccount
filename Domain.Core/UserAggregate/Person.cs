namespace Domain.Core.UserAggregate
{
    public class Person : Client
    {
        public required DateTime DateOfBirth { get; set; }                   // Дата рождения
        public required string PassportNumber { get; set; }                  // Серия и номер документа удостоверяющего личность
        public required string IssuingAuthority { get; set; }                // Кем выдан
        public required DateTime IssueDate { get; set; }                     // Дата выдачи
        public string? TaxIdentificationNumber { get; set; }                 // Идентификационный номер (при наличии)
        public required string RegistrationAddress { get; set; }             // Адрес регистрации
        public string? ResidentialAddress { get; set; }                      // Адрес проживания (если отличается от адреса регистрации)
    }
}
