using LegalexAccount.BLL.DTO;
using LegalexAccount.Utility.Types;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Registration
{
    public class RegistrationCommand : IRequest
    {
        public ClientType ClientType { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = null;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? SurName { get; set; } = null;


        public RegistrationCommand()
        {
        }
    }
}
