using Domain.Core.UserAggregate;


namespace Application.Core.DTO
{
    public class CaseDTO
    {
        public int Id { get; set; }
        public required DateTime StartDate { get; set; }
        public int? EstimatedDaysToEnd { get; set; }
        public required Client Customer { get; set; }
        public List<Specialist>? Assignees { get; set; }
        public required string Description { get; set; }
        public required bool IsArchived { get; set; }
        public DateTime? ArchivedAt { get; set; }
    }
}
