using LegalexAccount.DAL.Models.CaseAggregate;


namespace LegalexAccount.DAL.Models.UserAggregate
{
    public abstract class Client : User
    {
        public List<Case> Cases { get; set; }
    }
}
