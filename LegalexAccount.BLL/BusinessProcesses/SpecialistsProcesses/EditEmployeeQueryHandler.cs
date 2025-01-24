using LegalexAccount.BLL.DTO;
using LegalexAccount.BLL.Services.MailSender;
using LegalexAccount.DAL;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.SpecialistsProcesses
{
    public class EditEmployeeQueryHandler : IRequestHandler<EditEmployeeQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;


        public EditEmployeeQueryHandler(IUnitOfWork unitOfWork, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }

        public async Task Handle(EditEmployeeQuery request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Specialists.UpdateAsync(request.Model.ToModel());
            await _mailService.SendEmailAsync(request.MailRequest);
        }
    }
}
