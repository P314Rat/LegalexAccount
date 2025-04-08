using Application.Core.DTO;
using AutoMapper;
using Domain.Core.UserAggregate;
using Infrastructure.Specifications.UserAggregate;
using MediatR;


namespace Application.Core.BusinessLogic.AccountProcess.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetProfileQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProfileDTO> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            //var profile = _unitOfWork.Repository<User, Guid>()
            //    .GetAsync(new UserByEmailSpecification(request.Email));

            throw new NotImplementedException();
        }
    }
}
