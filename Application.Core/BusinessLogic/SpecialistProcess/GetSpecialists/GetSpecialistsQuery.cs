using Application.Core.DTO;
using MediatR;


namespace Application.Core.BusinessLogic.SpecialistProcess.GetSpecialists
{
    public class GetSpecialistsQuery : IRequest<List<SpecialistDTO>?> { }
}
