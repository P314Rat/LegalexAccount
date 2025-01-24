using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class CreateEmployeeQuery : IRequest
    {
        public SpecialistDTO Model { get; set; }


        public CreateEmployeeQuery(SpecialistDTO model)
        {
            Model = model;
        }
    }
}
