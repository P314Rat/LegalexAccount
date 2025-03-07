namespace Domain.Core.UserAggregate
{
    public class Legal : Client
    {
        public required string OrganizationName { get; set; }        // Полное наименование организации
        public required string LegalAddress { get; set; }            // Юридический адрес
        public string? PostalAddress { get; set; }                   // Почтовый адрес (если отличается от юридического)
        public required string LegalID { get; set; }                 // УНП (или иной идентификатор)
        public required string BankAccountNumber { get; set; }       // Расчётный счёт 
        public required string BankName { get; set; }                // Название банка 
        public required string BankAddress { get; set; }             // Адрес банка 
        public required string BankIdenticationCode { get; set; }    // БИК (банковский идентификационный код)
        public required string PositionHeld { get; set; }            // Занимаемая должность
        public required string Powers { get; set; }                  // На основании чего действует
    }
}
