namespace LegalexAccount.DAL.Models.UserAggregate
{
    public class Person : Client
    {
        public DateTime DateOfBirth { get; set; }                           // Дата рождения
        public string PassportNumber { get; set; } = string.Empty;          // Номер паспорта
        public string IssuingAuthority { get; set; } = string.Empty;        // Орган, выдавший паспорт
        public DateTime IssueDate { get; set; }                             // Дата выдачи паспорта
        public string TaxIdentificationNumber { get; set; } = string.Empty; // ИНН (индивидуальный налоговый номер)
        public string ResidentialAddress { get; set; } = string.Empty;      // Адрес проживания
        public string RegistrationAddress { get; set; } = string.Empty;      // Адрес регистрации (если отличается от проживания)
    }
}
