using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class CreateLegalCommand : IRequest
    {
        public LegalDTO model { get; set; }


        public CreateLegalCommand(LegalDTO model)
        {
            this.model = model;
        }
    }
}
