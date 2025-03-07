using Application.Core.DTO;
using MediatR;


namespace Application.Core.BusinessLogic.ClientProcess.GetClientByEmail
{
    public class GetClientByEmailQuery : IRequest<ClientDTO?>
    {
        public string Email { get; set; }


        public GetClientByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
