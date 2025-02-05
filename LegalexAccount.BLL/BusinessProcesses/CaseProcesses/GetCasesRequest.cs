using LegalexAccount.BLL.DTO.Case;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.CaseProcesses
{
    public class GetCasesRequest : IRequest<IEnumerable<CaseDTO>>
    {
        public int Id { get; set; }


        public GetCasesRequest(int id = 0)
        {
            Id = id;
        }
    }
}
