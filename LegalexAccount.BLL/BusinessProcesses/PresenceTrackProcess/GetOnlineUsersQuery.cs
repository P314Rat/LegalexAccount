using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.PresenceTrackProcess
{
    public class GetOnlineUsersQuery : IRequest<List<string>>
    {
    }
}
