using Utilities.Types;


namespace Presentation.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } // Дата
        public ClientRole ClientType { get; set; }
        public ServiceType Service { get; set; }
        
    }
}
