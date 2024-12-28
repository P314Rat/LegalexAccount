using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


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
            var specialistsQuery = _unitOfWork.Specialists.AsQueryable();

            if (request.Email != null)
            {
                var specialists = await specialistsQuery.Where(x => x.Email == request.Email).FirstOrDefaultAsync();

                if (specialists != null)
                {
                    var specialistDTO = specialists.ToDTO();
                    var result = specialistDTO == null ? new List<SpecialistDTO>() : new List<SpecialistDTO>() { specialistDTO };

                    return result;
                }
                else
                    throw new Exception("Specialist is not exists");
            }
            else
            {
                var result = await specialistsQuery.AsQueryable().Select(x => x.ToDTO()).ToListAsync();

                return result;
            }
        }
    }
}
