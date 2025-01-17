using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class CreatePersonCommand : IRequest
    {
        public PersonDTO model { get; set; }


        public CreatePersonCommand(PersonDTO model)
        {
            this.model = model;
        }
    }
}
