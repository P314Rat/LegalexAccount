namespace LegalexAccount.DAL.Models.UserAggregate
{
    public class Legal : Client
    {
        public string OrganizationName { get; set; } = string.Empty;    // Наименование организации
        public string LegalForm { get; set; } = string.Empty;           // Организационно-правовая форма (например, ООО, АО)
        public string PayerAccountNumber { get; set; } = string.Empty;  // УНП
        public string PositionHeld { get; set; } = string.Empty;        // Занимаемая должность
        public string GroundsForAsk { get; set; } = string.Empty;       // Основания обращения
        public string LegalAddress { get; set; } = string.Empty;        // Юридический адрес
        public string? ActualAddress { get; set; } = null;              // Фактический адрес (если отличается от юридического) ?
        public string? BankAccountNumber { get; set; } = null;          // Номер банковского счета ?
        public string? BankName { get; set; } = null;                   // Название банка ?
        public string? BankIdentificationCode { get; set; } = null;     // БИК (банковский идентификационный код) ?
    }
}
