using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.UserAggregate;
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

        public Task<List<SpecialistDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var specialistsQuery = _unitOfWork.Specialists.AsQueryable();

            if (request.Email != null)
                specialistsQuery = specialistsQuery.Where(x => x.Email == request.Email);


            return specialistsQuery.Select(x => x.ToDTO()).ToListAsync();
        }
    }
}
