using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL.Models;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Identification
{
    public class IdentificationQueryHandler : IRequestHandler<IdentificationQuery, ProfileDTO>
    {
        private readonly IUnitOfWork _unitOfWork;


        public IdentificationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfileDTO> Handle(IdentificationQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            return user.ToProfileDTO();
        }
    }
}
