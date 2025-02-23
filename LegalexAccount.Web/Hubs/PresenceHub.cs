using LegalexAccount.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;


namespace LegalexAccount.Web.Hubs
{
    [Authorize]
    public class PresenceHub : Hub
    {
        private readonly PresenceTrackerService _tracker;


        public PresenceHub(PresenceTrackerService tracker)
        {
            _tracker = tracker;
        }

        public override async Task OnConnectedAsync()
        {
            string userId = Context.User?.Identity?.Name;

            if (!string.IsNullOrEmpty(userId))
            {
                var isFirstConnection = await _tracker.UserConnected(userId, Context.ConnectionId);

                if (isFirstConnection)
                    await Clients.Others.SendAsync("UserOnline", userId);

                var onlineUsers = await _tracker.GetOnlineUsers();
                await Clients.Caller.SendAsync("OnlineUsers", onlineUsers);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string userId = Context.User?.Identity?.Name;

            if (!string.IsNullOrEmpty(userId))
            {
                bool isLastConnection = await _tracker.UserDisconnected(userId, Context.ConnectionId);

                if (isLastConnection)
                    await Clients.Others.SendAsync("UserOffline", userId);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
