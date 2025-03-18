using Application.Core.DTO.UserObject;
using AutoMapper;
using Infrastructure;
using MediatR;


namespace Application.Core.BusinessLogic.ProfileProcess.GetShortProfile
{
    public class GetShortProfileQueryHandler : IRequestHandler<GetShortProfileQuery, UserDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetShortProfileQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO?> Handle(GetShortProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (user == null)
                return null;

            return _mapper.Map<UserDTO>(user);
        }
    }
}
