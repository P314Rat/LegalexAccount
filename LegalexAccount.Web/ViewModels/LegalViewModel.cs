using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Web.ViewModels
{
    public class LegalViewModel : UserViewModel
    {
        [Required(ErrorMessage = "Это необходимое поле")]
        public string OrganizationName { get; set; } = string.Empty;        // Полное наименование организации
        [Required(ErrorMessage = "Это необходимое поле")]
        public string LegalAddress { get; set; } = string.Empty;            // Юридический адрес
        public string? PostalAddress { get; set; } = null;                  // Почтовый адрес (если отличается от юридического)
        [Required(ErrorMessage = "Это необходимое поле")]
        public string LegalID { get; set; } = string.Empty;                 // УНП (или иной идентификатор)
        [Required(ErrorMessage = "Это необходимое поле")]
        public string BankAccountNumber { get; set; } = string.Empty;       // Расчётный счёт
        [Required(ErrorMessage = "Это необходимое поле")]
        public string BankName { get; set; } = string.Empty;                // Название банка
        [Required(ErrorMessage = "Это необходимое поле")]
        public string BankAddress { get; set; } = string.Empty;             // Адрес банка
        [Required(ErrorMessage = "Это необходимое поле")]
        public string BankIdenticationCode { get; set; } = string.Empty;    // БИК (банковский идентификационный код)
        [Required(ErrorMessage = "Это необходимое поле")]
        public string PositionHeld { get; set; } = string.Empty;            // Занимаемая должность
        [Required(ErrorMessage = "Это необходимое поле")]
        public string Powers { get; set; } = string.Empty;                  // На основании чего действует
    }
}
