using Application.Core.DTO.UserObject;
using AutoMapper;
using Domain.Core.UserAggregate;
using Infrastructure;
using MediatR;


namespace Application.Core.BusinessLogic.ClientProcess.GetClients
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientDTO?>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetClientsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<ClientDTO?>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var legalEntities = _unitOfWork.LegalEntities.AsQueryable()
                .Select(x => _mapper.Map<LegalDTO>(x))
                .ToList();
            var individuals = _unitOfWork.Individuals.AsQueryable()
                .Cast<Person>()
                .Select(x => _mapper.Map<PersonDTO>(x))
                .ToList();
            var result = legalEntities.Cast<ClientDTO?>().Concat(individuals.Cast<ClientDTO?>())
                .ToList();

            return Task.FromResult(result ?? new List<ClientDTO?>());
        }
    }
}
