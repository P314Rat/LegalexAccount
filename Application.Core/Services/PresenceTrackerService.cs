namespace Application.Core.Services
{
    public class PresenceTrackerService
    {
        private static readonly Dictionary<string, HashSet<string>> OnlineUsers = new();


        public Task<bool> UserConnected(string userId, string connectionId)
        {
            lock (OnlineUsers)
            {
                if (!OnlineUsers.ContainsKey(userId))
                {
                    OnlineUsers[userId] = new HashSet<string>();
                }

                var isOnline = OnlineUsers[userId].Count == 0;
                OnlineUsers[userId].Add(connectionId);
                return Task.FromResult(isOnline);
            }
        }

        public Task<bool> UserDisconnected(string userId, string connectionId)
        {
            lock (OnlineUsers)
            {
                if (!OnlineUsers.ContainsKey(userId)) return Task.FromResult(false);

                OnlineUsers[userId].Remove(connectionId);
                if (OnlineUsers[userId].Count == 0)
                {
                    OnlineUsers.Remove(userId);
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
        }

        public bool IsOnline(string userId)
        {
            lock (OnlineUsers)
            {
                return OnlineUsers.Keys.Any(x => x == userId);
            }
        }

        public Task<List<string>> GetOnlineUsers()
        {
            lock (OnlineUsers)
            {
                return Task.FromResult(OnlineUsers.Keys.ToList());
            }
        }
    }
}
