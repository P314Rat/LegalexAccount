using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<SpecialistDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetEmployeesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SpecialistDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var specialistsQuery = _unitOfWork.Specialists.AsQueryable();

            if (request.Email != null)
            {
                var specialist = (await specialistsQuery.Where(x => x.Email == request.Email).FirstOrDefaultAsync())?.ToDTO();

                if (specialist != null)
                {
                    var result = specialist == null ? new List<SpecialistDTO>()
                        : new List<SpecialistDTO>() { specialist };

                    return result;
                }
                else
                    return new List<SpecialistDTO>();
            }
            else
            {
                var result = specialistsQuery.AsQueryable().Select(x => x.ToDTO()).ToList();

                return result;
            }
        }
    }
}
