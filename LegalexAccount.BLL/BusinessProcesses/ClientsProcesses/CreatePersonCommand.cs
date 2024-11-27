using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class CreatePersonCommand : IRequest
    {
        public PersonDTO _model { get; set; }


        public CreatePersonCommand(PersonDTO model)
        {
            _model = model;
        }
    }
}
