using LegalexAccount.BLL.DTO.Case;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.CaseProcesses
{
    public class GetCasesRequest : IRequest<IEnumerable<CaseDTO>>
    {
        public GetCasesRequest() { }
    }
}
