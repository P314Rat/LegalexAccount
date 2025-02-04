namespace LegalexAccount.BLL.DTO.Case
{
    public class CaseDTO
    {
        public DateTime? StartDate { get; set; } = null;
        public int? EstimatedDaysToEnd { get; set; } = null;
        public UserDTO? Customer { get; set; } = null;
        public List<SpecialistDTO>? Assignees { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
