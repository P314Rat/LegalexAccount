using Application.Core.DTO;
using AutoMapper;
using Domain.Core.UserAggregate;
using Infrastructure.Specifications.UserAggregate;
using MediatR;


namespace Application.Core.BusinessLogic.ProfileProcess.GetShortProfile
{
    public class GetShortProfileQueryHandler : IRequestHandler<GetShortProfileQuery, ProfileDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetShortProfileQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProfileDTO> Handle(GetShortProfileQuery request, CancellationToken cancellationToken)
        {
            var user = (await _unitOfWork.Repository<User, Guid>()
                .GetAsync(new UserByEmailSpecification(request.Email)))?.First();

            return _mapper.Map<ProfileDTO>(user);
        }
    }
}
