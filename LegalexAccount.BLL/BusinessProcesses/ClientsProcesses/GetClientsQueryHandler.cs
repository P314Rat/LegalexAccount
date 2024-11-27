using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.UserAggregate;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetClientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserDTO>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {

            if (request.Email == null)
            {
                var clients = await _unitOfWork.Clients.GetAllAsync();
                var legalDTOs = clients.Where(x => x != null && x is Legal).Select(x => ((Legal)x).ToDTO());
                var personDTOs = clients.Where(x => x != null && x is Person).Select(x => ((Person)x).ToDTO());
                var userDTOs = legalDTOs.Cast<UserDTO>().Union(personDTOs.Cast<UserDTO>()).ToList();

                return userDTOs;
            }
            else
            {
                var client = await _unitOfWork.Clients.GetByEmailAsync(request.Email);

                if (client is Legal l)
                    return new List<UserDTO> { l.ToDTO() };
                else if (client is Person p)
                    return new List<UserDTO> { p.ToDTO() };
                else
                    throw new Exception("Something went wrong with getting client");
            }
        }
    }
}
