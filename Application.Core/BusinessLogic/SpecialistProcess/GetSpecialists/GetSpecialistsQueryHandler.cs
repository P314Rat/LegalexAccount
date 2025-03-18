using Application.Core.DTO.UserObject;
using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Core.BusinessLogic.SpecialistProcess.GetSpecialists
{
    public class GetSpecialistsQueryHandler : IRequestHandler<GetSpecialistsQuery, List<SpecialistDTO>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSpecialistsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SpecialistDTO>?> Handle(GetSpecialistsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Specialists.AsQueryable()
                .Select(x => _mapper.Map<SpecialistDTO>(x))
                .ToListAsync();

            return result;
        }
    }
}
