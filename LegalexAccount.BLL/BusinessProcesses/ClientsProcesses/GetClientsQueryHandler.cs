using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL.Models;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ProfileDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetClientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProfileDTO>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            if (request.Email == null)
                return (await _unitOfWork.Clients.GetAllAsync()).Select(x => x.ToProfileDTO()).ToList();
            else
            {
                var profile = await _unitOfWork.Clients.GetByEmailAsync(request.Email);

                return new List<ProfileDTO> { profile.ToProfileDTO() };
            }
        }
    }
}
