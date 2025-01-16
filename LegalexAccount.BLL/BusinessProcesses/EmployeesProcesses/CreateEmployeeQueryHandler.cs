using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.EmployeesProcesses
{
    public class CreateEmployeeQueryHandler : IRequestHandler<CreateEmployeeQuery>
    {
        public Task Handle(CreateEmployeeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
