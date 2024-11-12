namespace LegalexAccount.BLL.DTO
{
    public class LegalDTO : UserDTO
    {
        public string? OrganizationName { get; set; } = null;        // Полное наименование организации
        public string? LegalAddress { get; set; } = null;            // Юридический адрес
        public string? PostalAddress { get; set; } = null;           // Почтовый адрес (если отличается от юридического)
        public string? LegalID { get; set; } = null;                 // УНП (или иной идентификатор)
        public string? BankAccountNumber { get; set; } = null;       // Расчётный счёт
        public string? BankName { get; set; } = null;                // Название банка
        public string? BankAddress { get; set; } = null;             // Адрес банка
        public string? BankIdenticationCode { get; set; } = null;    // БИК (банковский идентификационный код)
        public string? PositionHeld { get; set; } = null;            // Занимаемая должность
        public string? Powers { get; set; } = null;                  // На основании чего действует
    }
}
