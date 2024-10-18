using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Utility.Types
{
    public enum ClientType
    {
        [Display(Name = "Юридическое лицо")]
        Legal,
        [Display(Name = "Физическое лицо")]
        Person
    }
}
