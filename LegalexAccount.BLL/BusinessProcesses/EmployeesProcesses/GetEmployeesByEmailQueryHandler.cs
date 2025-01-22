using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses
{
    public class GetEmployeesByEmailQueryHandler : IRequestHandler<GetEmployeesByEmailQuery, SpecialistDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetEmployeesByEmailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SpecialistDTO?> Handle(GetEmployeesByEmailQuery request, CancellationToken cancellationToken)
        {
            var result = (
                await _unitOfWork.Specialists.AsQueryable()
                .Where(x => x.Email == request.Email)
                .FirstOrDefaultAsync()
                )?.ToDTO();

            return result;
        }
    }
}
