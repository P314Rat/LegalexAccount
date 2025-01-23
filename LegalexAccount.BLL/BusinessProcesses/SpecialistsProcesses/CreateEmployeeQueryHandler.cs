using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class CreateEmployeeQueryHandler : IRequestHandler<CreateEmployeeQuery>
    {
        private readonly IUnitOfWork _unitOfWork;


        public CreateEmployeeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateEmployeeQuery request, CancellationToken cancellationToken)
        {
            var model = request.model.ToModel();

            await _unitOfWork.Specialists.CreateAsync(model);
        }
    }
}
