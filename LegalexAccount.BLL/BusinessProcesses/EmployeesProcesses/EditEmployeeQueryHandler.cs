using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Repositories;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses
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
