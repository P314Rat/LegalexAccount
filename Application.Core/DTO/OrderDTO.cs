using Utilities.Types;


namespace Application.Core.DTO
{
    public class OrderDTO
    {
        public DateTime? CreatedAt { get; set; } // Дата
        public ClientRole? ClientType { get; set; }
        public ServiceType? Service { get; set; }
        public string? ClientName { get; set; }
        public string? Contact { get; set; }
        public string? Description { get; set; }
    }
}
