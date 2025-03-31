using Application.Core.DTO;
using AutoMapper;
using Infrastructure;
using MediatR;


namespace Application.Core.BusinessLogic.AccountProcess.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetProfileQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfileDTO> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetAsync(request.Email);
            var result = _mapper.Map<ProfileDTO>(user);

            return result;
        }
    }
}
