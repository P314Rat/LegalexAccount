namespace LegalexAccount.BLL.DTO
{
    public class LegalDTO : UserDTO
    {
        public string OrganizationName { get; set; } = string.Empty;        // Полное наименование организации
        public string LegalAddress { get; set; } = string.Empty;            // Юридический адрес
        public string? PostalAddress { get; set; } = null;                  // Почтовый адрес (если отличается от юридического)
        public string LegalID { get; set; } = string.Empty;                 // УНП (или иной идентификатор)
        public string BankAccountNumber { get; set; } = string.Empty;       // Расчётный счёт
        public string BankName { get; set; } = string.Empty;                // Название банка
        public string BankAddress { get; set; } = string.Empty;             // Адрес банка
        public string BankIdentificationCode { get; set; } = string.Empty;  // БИК (банковский идентификационный код)
        public string PositionHeld { get; set; } = string.Empty;            // Занимаемая должность
        public string Powers { get; set; } = string.Empty;                  // На основании чего действует
    }
}
