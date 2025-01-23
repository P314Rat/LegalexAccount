using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class EditEmployeeQuery : IRequest
    {
        public SpecialistDTO model { get; set; }


        public EditEmployeeQuery(SpecialistDTO model)
        {
            this.model = model;
        }
    }
}
