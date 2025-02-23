using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;


namespace LegalexAccount.Web.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(Guid chatId, Guid senderId, string message)
        {
            // Отправка клиентам
            await Clients.Group(chatId.ToString()).SendAsync("ReceiveMessage", senderId, message);
        }

        public async Task JoinChat(Guid chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        }

        public async Task LeaveChat(Guid chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
        }
    }
}
