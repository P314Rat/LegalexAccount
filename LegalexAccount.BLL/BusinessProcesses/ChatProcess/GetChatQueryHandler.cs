using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.ChatAggregate;
using LegalexAccount.DAL.Models.UserAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.BLL.BusinessProcesses.ChatProcess
{
    public class GetChatQueryHandler : IRequestHandler<GetChatQuery, ChatDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetChatQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ChatDTO?> Handle(GetChatQuery request, CancellationToken cancellationToken)
        {
            //var chat = await _unitOfWork.Chats.AsQueryable().Where(x => x.Members.Count == 2
            //    && x.Members.Any(t => t.Email == request.OwnerEmail
            //    && x.Members.Any(t => t.Email == request.ReceiverEmail)))
            //    .FirstOrDefaultAsync();
            //var result = new ChatDTO();

            //if (chat == null)
            //{
            //    var owner = await _unitOfWork.Users.GetByEmailAsync(request.OwnerEmail);
            //    var receiver = await _unitOfWork.Users.GetByEmailAsync(request.ReceiverEmail);
            //    var item = new Chat
            //    {
            //        Name = receiver?.LastName ?? throw new Exception("чито за хуета?!"),
            //        Members = new List<User> { owner, receiver },
            //        Messages = new List<Message>()
            //    };

            //    await _unitOfWork.Chats.CreateAsync(item);

            //    result.Name = item.Name;
            //    result.Members = item.Members.Select(x => x.ToDTO()).ToList();
            //    result.Messages = new List<MessageDTO>();
            //}
            //else
            //{
            //    result.Name = chat.Name;
            //    result.Members = chat.Members.Select(x => x.ToDTO()).ToList();
            //    result.Messages = new List<MessageDTO>();
            //}

            //    return result;

            throw new NotImplementedException();
        }
    }
}
