using Application.Core.DTO.UserObject;
using AutoMapper;
using Domain.Core.UserAggregate;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Core.BusinessLogic.ClientProcess.GetClientByEmail
{
    public class GetClientByEmailQueryHandler : IRequestHandler<GetClientByEmailQuery, ClientDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetClientByEmailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClientDTO?> Handle(GetClientByEmailQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.Clients.AsQueryable().Where(x => x.Email == request.Email).FirstOrDefaultAsync();

            if (client != null)
            {
                ClientDTO? clientDTO = client switch
                {
                    Legal legalClient => _mapper.Map<LegalDTO>(legalClient),
                    Person person => _mapper.Map<PersonDTO>(person),
                    _ => null
                };

                return clientDTO;
            }

            return null;
        }
    }
}
