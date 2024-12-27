using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;


        public CreatePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreatePersonCommand command, CancellationToken cancellationToken)
        {
            var model = command._model.ToModel();

            await _unitOfWork.Individuals.CreateAsync(model);
        }
    }
}
