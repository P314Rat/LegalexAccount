using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ChatProcess
{
    public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand>
    {
        public Task Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
