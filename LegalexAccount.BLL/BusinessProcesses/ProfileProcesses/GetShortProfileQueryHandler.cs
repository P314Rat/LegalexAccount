using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ProfileProcesses
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

            if (user == null)
                return null;

            var profile = new ShortProfileDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return profile;
        }
    }
}
