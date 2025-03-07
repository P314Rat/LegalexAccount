using Application.Core.DTO;
using Infrastructure;
using MediatR;


namespace Application.Core.BusinessLogic.ProfileProcess.GetShortProfile
{
    public class GetShortProfileQueryHandler : IRequestHandler<GetShortProfileQuery, ShortProfileDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetShortProfileQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShortProfileDTO?> Handle(GetShortProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            var profile = user != null ? new ShortProfileDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            } : null;

            return profile;
        }
    }
}
