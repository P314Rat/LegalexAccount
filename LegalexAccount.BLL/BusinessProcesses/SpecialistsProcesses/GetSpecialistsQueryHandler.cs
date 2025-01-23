using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetSpecialistsQuery, IEnumerable<SpecialistDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetEmployeesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SpecialistDTO>> Handle(GetSpecialistsQuery request, CancellationToken cancellationToken)
        {
            var specialistsQuery = _unitOfWork.Specialists.AsQueryable();
            var result = await specialistsQuery.AsQueryable().Select(x => x.ToDTO()).ToListAsync();

            return result;
        }
    }
}
