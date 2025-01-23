using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ProfileProcesses
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetProfileQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfileDTO?> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (user != null)
            {
                var profile = new ProfileDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    SurName = user.SurName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };

                return profile;
            }

            return null;
        }
    }
}
