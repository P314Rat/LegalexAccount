using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses
{
    public class GetEmployeesByEmailQuery : IRequest<SpecialistDTO?>
    {
        public string Email { get; set; }


        public GetEmployeesByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
