using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.Web.ViewModels
{
    public class CaseViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int? EstimatedDaysToEnd { get; set; } = null;
        public Client Customer { get; set; }
        public List<Specialist>? Assignee { get; set; } = null;
        public string Description { get; set; } = string.Empty;
    }
}
