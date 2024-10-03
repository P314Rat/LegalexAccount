using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Models.CaseAggregate
{
    public class Case
    {
        public int Id { get; set; }
        public Client Customer { get; set; }
        public Specialist Assignee { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
