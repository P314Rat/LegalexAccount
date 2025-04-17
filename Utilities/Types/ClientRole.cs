using System.ComponentModel.DataAnnotations;


namespace Utilities.Types
{
    public enum ClientRole
    {
        [Display(Name = "Юридическое лицо")]
        Legal,
        [Display(Name = "Физическое лицо")]
        Person
    }
}
