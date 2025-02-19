using LegalexAccount.BLL.DTO;
using LegalexAccount.BLL.Services.MailSender;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class CreateEmployeeQueryHandler : IRequestHandler<CreateEmployeeQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;


        public CreateEmployeeQueryHandler(IUnitOfWork unitOfWork, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }

        public async Task Handle(CreateEmployeeQuery request, CancellationToken cancellationToken)
        {
            var isSpecialistExist = await ((IUserRepository<Specialist>)_unitOfWork.Specialists).IsExistsAsync(request.Model.Email);

            var mail = new MailRequest
            {
                ToEmail = request.Model.Email,
                Subject = "Регистрация",
            };

            if (!isSpecialistExist)
            {
                await _unitOfWork.Specialists.CreateAsync(request.Model.ToModel());
                await _mailService.SendRegistrationDataAsync(mail, request.Model.FirstName, request.Model.Password);

                return;
            }

            throw new Exception("Specialist already exists");
        }
    }
}
