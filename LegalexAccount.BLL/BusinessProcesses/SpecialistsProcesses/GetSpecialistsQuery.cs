using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class GetSpecialistsQuery : IRequest<IEnumerable<SpecialistDTO>>
    {
        public GetSpecialistsQuery() { }
    }
}
