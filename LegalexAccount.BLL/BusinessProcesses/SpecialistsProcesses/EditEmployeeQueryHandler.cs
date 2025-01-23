using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class EditEmployeeQueryHandler : IRequestHandler<EditEmployeeQuery>
    {
        private readonly IUnitOfWork _unitOfWork;


        public EditEmployeeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EditEmployeeQuery request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Specialists.UpdateAsync(request.model.ToModel());
        }
    }
}
