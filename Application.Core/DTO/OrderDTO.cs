using Utilities.Types;


namespace Application.Core.DTO
{
    public class OrderDTO
    {
        public int? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ClientRole? ClientType { get; set; }
        public string? ClientName { get; set; }
        public ServiceType? ServiceType { get; set; }
        public string? Contact { get; set; }
        public string? Description { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? ArchivedAt { get; set; }
    }
}
