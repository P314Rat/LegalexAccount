using LegalexAccount.BLL.Services;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.PresenceTrackProcess
{
    class GetOnlineUsersHandler : IRequestHandler<GetOnlineUsersQuery, List<string>>
    {
        private readonly PresenceTracker _tracker;


        public GetOnlineUsersHandler(PresenceTracker tracker)
        {
            _tracker = tracker;
        }

        public async Task<List<string>> Handle(GetOnlineUsersQuery request, CancellationToken cancellationToken)
        {
            return await _tracker.GetOnlineUsers();
        }
    }
}
