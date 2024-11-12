using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class CreateLegalCommand : IRequest
    {
        public LegalDTO _model { get; set; }


        public CreateLegalCommand(LegalDTO model)
        {
            _model = model;
        }
    }
}
