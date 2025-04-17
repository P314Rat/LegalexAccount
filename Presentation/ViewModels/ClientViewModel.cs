using Utilities.Types;


namespace Presentation.ViewModels
{
    public class ClientViewModel
    {
        public ClientRole Type { get; set; }
        public string? OrganizationName { get; set; }
        public required string Client { get; set; }
        public required string Email { get; set; }
    }
}
