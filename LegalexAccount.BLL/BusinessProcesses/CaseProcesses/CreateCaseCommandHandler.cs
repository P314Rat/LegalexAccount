using LegalexAccount.BLL.DTO.Case;
using LegalexAccount.DAL;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.CaseProcesses
{
    public class CreateCaseCommandHandler : IRequestHandler<CreateCaseCommand>
    {
        private IUnitOfWork _unitOfWork;

        public CreateCaseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCaseCommand request, CancellationToken cancellationToken)
        {
            var model = await request.model.ToModel(_unitOfWork);

            await _unitOfWork.Cases.CreateAsync(model);
        }
    }
}
