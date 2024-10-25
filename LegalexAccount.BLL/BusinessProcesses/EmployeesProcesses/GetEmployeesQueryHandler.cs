using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL.Models;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<SpecialistDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetEmployeesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SpecialistDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var specialists = (await _unitOfWork.Specialists.GetAllAsync()).Where(x => x.Email != request.Email);
            var specialistModels = specialists.Select(x => x.ToDTO()).ToList();

            return specialistModels;
        }
    }
}
