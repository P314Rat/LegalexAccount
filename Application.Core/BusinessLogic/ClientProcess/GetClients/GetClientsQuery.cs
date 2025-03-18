using Application.Core.DTO.UserObject;
using MediatR;


namespace Application.Core.BusinessLogic.ClientProcess.GetClients
{
    public class GetClientsQuery : IRequest<List<ClientDTO?>> { }
}
