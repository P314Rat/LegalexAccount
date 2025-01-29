using LegalexAccount.BLL.DTO;
using LegalexAccount.BLL.Services.MailSender;
using LegalexAccount.DAL;
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
            var isSpecialistExist = await ((IUserRepository)_unitOfWork.Specialists).IsExistsAsync(request.Model.Email);

            var mail = new MailRequest
            {
                ToEmail = request.Model.Email,
                Subject = "Registration",
                Body = $"Your password: {request.Model.Password}"
            };

            if (!isSpecialistExist)
            {
                await _unitOfWork.Specialists.CreateAsync(request.Model.ToModel());
                await _mailService.SendEmailAsync(mail);

                return;
            }

            throw new Exception("Specialist already exists");
        }
    }
}
