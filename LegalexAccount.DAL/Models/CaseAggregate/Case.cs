using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Models.CaseAggregate
{
    public class Case : BaseEntity<int>
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public int? EstimatedDaysToEnd { get; set; } = null;
        public Client Customer { get; set; }
        public List<Specialist>? Assignee { get; set; } = null;
        public string Description { get; set; } = string.Empty;
    }
}
