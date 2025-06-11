using Application.Core.DTO;
using AutoMapper;
using Domain.Core.UserAggregate;
using Infrastructure.Specifications.UserAggregate;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.AccountProcess.GetSpecialists
{
    public class GetSpecialistsQueryHandler : IRequestHandler<GetSpecialistsQuery, PagedResult<ProfileDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetSpecialistsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<PagedResult<ProfileDTO>> Handle(GetSpecialistsQuery request, CancellationToken cancellationToken)
        {
            var totalSpecialistsCount = await _unitOfWork.Repository<Specialist, Guid>().CountAsync(new SpecialistSpecification(request.Skip, request.Take));
            var specialists = (await _unitOfWork.Repository<Specialist, Guid>()
                .GetAsync(new SpecialistSpecification(request.Skip, request.Take)))
                .Select(_mapper.Map<ProfileDTO>);
            var result = PagedResult<ProfileDTO>.Create(specialists, totalSpecialistsCount, request.Take, request.Skip / request.Take + 1);

            return result;
        }
    }
}
