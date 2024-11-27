using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.BLL.DTO.Case
{
    public class CaseDTO
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; } = null;
        public int? EstimatedDaysToEnd { get; set; } = null;
        public Client? Customer { get; set; } = null;
        public List<Specialist>? Assignee { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
