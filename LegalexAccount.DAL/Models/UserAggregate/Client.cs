using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.DAL.Models.UserAggregate
{
    public enum ClientType
    {
        [Display(Name = "Юридическое лицо")]
        Legal,
        [Display(Name = "Физическое лицо")]
        Person
    }

    public class Client : User
    {
        public ClientType Type { get; set; }
    }
}
