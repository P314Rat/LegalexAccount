using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses
{
    public class GetEmployeesQuery : IRequest<List<SpecialistDTO>>
    {
        public string? Email { get; set; }


        public GetEmployeesQuery(string? email = null)
        {
            Email = email;
        }
    }
}
