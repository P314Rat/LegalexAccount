using Application.Core.DTO;
using AutoMapper;
using Domain.Core.UserAggregate;
using Infrastructure.Specifications.ClientAggregate;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.AccountProcess.GetClients
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, PagedResult<ProfileDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetClientsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResult<ProfileDTO>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var totalClientsCount = await _unitOfWork.Repository<Client, Guid>().CountAsync();
            var clients = (await _unitOfWork.Repository<Client, Guid>()
                .GetAsync(new ClientSpecification(request.Skip, request.Take)))
                .Select(_mapper.Map<ProfileDTO>);
            var result = PagedResult<ProfileDTO>.Create(clients, totalClientsCount, request.Take, request.Skip / request.Take + 1);

            return result;
        }
    }
}
