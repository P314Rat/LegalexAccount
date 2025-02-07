using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Models.CaseAggregate
{
    public class Case : BaseEntity<int>
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public int? EstimatedDaysToEnd { get; set; } = null;
        public Guid CustomerId { get; set; }
        public Client Customer { get; set; }
        public List<Specialist> Assignees { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsArchived { get; set; } = false;
        public DateTime? ArchivedAt { get; set; }
    }
}
