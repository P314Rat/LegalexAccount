using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses
{
    public class GetEmployeesQuery : IRequest<IEnumerable<SpecialistDTO>>
    {
        public GetEmployeesQuery() { }
    }
}
