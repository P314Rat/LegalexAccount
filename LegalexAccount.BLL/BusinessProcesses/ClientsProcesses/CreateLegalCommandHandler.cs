using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL.Models;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class CreateLegalCommandHandler : IRequestHandler<CreateLegalCommand>
    {
        private readonly IUnitOfWork _unitOfWork;


        public CreateLegalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateLegalCommand command, CancellationToken cancellationToken)
        {
            var model = command._model.ToModel();

            await _unitOfWork.LegalEntities.CreateAsync(model);

        }
    }
}
