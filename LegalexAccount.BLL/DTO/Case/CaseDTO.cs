using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.BLL.DTO.Case
{
    public class CaseDTO
    {
        public DateTime? StartDate { get; set; } = null;
        public int? EstimatedDaysToEnd { get; set; } = null;
        public string? CustomerEmail { get; set; } = null;
        public string? AssigneeEmail { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
