using LegalexAccount.BLL.DTO.Case;
using LegalexAccount.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.BLL.BusinessProcesses.CaseProcesses
{
    public class GetCasesRequestHandler : IRequestHandler<GetCasesRequest, IEnumerable<CaseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetCasesRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CaseDTO>> Handle(GetCasesRequest request, CancellationToken cancellationToken)
        {
            var cases = _unitOfWork.Cases.AsQueryable()
                .Include(x => x.Customer)
                .Include(x => x.Assignees)
                .Select(x => x.ToDTO())
                .AsEnumerable();

            if (request.Id != 0)
                cases = cases.Where(x => x.Id == request.Id);

            return cases;
        }
    }
}
