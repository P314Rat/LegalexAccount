using Utilities.Types;


namespace Presentation.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ClientRole ClientType { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public ServiceType ServiceType { get; set; }
        public string Contact { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsArchived { get; set; }
        public DateTime? ArchivedAt { get; set; }
    }
}
