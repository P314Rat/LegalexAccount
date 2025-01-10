using LegalexAccount.BLL.DTO.Case;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.CaseProcesses
{
    public class CreateCaseCommand : IRequest
    {
        public CaseDTO model;

        public CreateCaseCommand(CaseDTO model)
        {
            this.model = model;
        }
    }
}
