using Utilities.Types;

namespace Presentation.ViewModels
{
    public class ClientViewModel
    {
        public ClientType? Type { get; set; }
        public string? OrganizationName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
