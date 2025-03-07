using System.ComponentModel.DataAnnotations;


namespace Utilities.Types
{
    public enum ClientType
    {
        [Display(Name = "Юридическое лицо")]
        Legal = 0,
        [Display(Name = "Физическое лицо")]
        Person = 1
    }
}
