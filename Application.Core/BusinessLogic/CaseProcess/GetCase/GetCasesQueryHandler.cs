using Application.Core.DTO;
using AutoMapper;
using Domain.Core.CaseAggregate;
using Infrastructure.Specifications.CaseAggregate;
using MediatR;


namespace Application.Core.BusinessLogic.CaseProcess.GetCase
{
    public class GetCasesQueryHandler : IRequestHandler<GetCasesQuery, List<CaseDTO>>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;


        public GetCasesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<CaseDTO>> Handle(GetCasesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
