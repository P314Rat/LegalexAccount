using System.ComponentModel.DataAnnotations;

namespace LegalexAccount.Utility.Types
{
    public enum UserType
    {
        [Display(Name = "Неизвестный")]
        Unknown = 0,
        [Display(Name = "Специалист")]
        Specialist,
        [Display(Name = "Физическое лицо")]
        Person,
        [Display(Name = "Юридическое лицо")]
        Legal
    }
}
