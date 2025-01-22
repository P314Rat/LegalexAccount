using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses
{
    public class CreateEmployeeQuery : IRequest
    {
        public SpecialistDTO model { get; set; }


        public CreateEmployeeQuery(SpecialistDTO model)
        {
            this.model = model;
        }
    }
}
