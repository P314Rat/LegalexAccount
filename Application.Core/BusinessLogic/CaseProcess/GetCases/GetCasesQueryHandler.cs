using Application.Core.DTO;
using AutoMapper;
using Domain.Core.CaseAggregate;
using Infrastructure.Specifications.CaseAggregate;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.CaseProcess.GetCase
{
    public class GetCasesQueryHandler : IRequestHandler<GetCasesQuery, PagedResult<CaseDTO>>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;


        public GetCasesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResult<CaseDTO>> Handle(GetCasesQuery request, CancellationToken cancellationToken)
        {
            var totalCasesCount = await _unitOfWork.Repository<Case, int>().CountAsync(new CaseSpecification(request.CurrentUserEmail, request.Skip, request.Take));
            var cases = (await _unitOfWork.Repository<Case, int>()
                .GetAsync(new CaseSpecification(request.CurrentUserEmail, request.Skip, request.Take)))
                .Select(_mapper.Map<CaseDTO>);

            var testList = cases.ToList();

            var result = PagedResult<CaseDTO>.Create(cases, totalCasesCount, request.Take, request.Skip / request.Take + 1);

            return result;
        }
    }
}
