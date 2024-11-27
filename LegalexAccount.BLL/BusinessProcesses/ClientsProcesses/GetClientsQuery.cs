using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class GetClientsQuery : IRequest<List<UserDTO>>
    {
        public string? Email { get; set; } = null;


        public GetClientsQuery(string? email = null)
        {
            Email = email;
        }
    }
}
