using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ChatProcess
{
    public class GetChatQuery : IRequest<ChatDTO?>
    {
        public string OwnerEmail { get; set; }
        public string ReceiverEmail { get; set; }


        public GetChatQuery(string ownerEmail, string receiverEmail)
        {
            OwnerEmail = ownerEmail;
            ReceiverEmail = receiverEmail;
        }
    }
}
