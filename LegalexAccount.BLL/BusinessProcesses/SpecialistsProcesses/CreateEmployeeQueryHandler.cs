using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Repositories.Contracts;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class CreateEmployeeQueryHandler : IRequestHandler<CreateEmployeeQuery>
    {
        private readonly IUnitOfWork _unitOfWork;


        public CreateEmployeeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateEmployeeQuery request, CancellationToken cancellationToken)
        {
            var isSpecialistExist = await ((IUserRepository)_unitOfWork.Specialists).IsExistsAsync(request.Model.Email);

            if (isSpecialistExist)
            {
                await _unitOfWork.Specialists.CreateAsync(request.Model.ToModel());

                return;
            }

            throw new Exception("Specialist already exists");
        }
    }
}
