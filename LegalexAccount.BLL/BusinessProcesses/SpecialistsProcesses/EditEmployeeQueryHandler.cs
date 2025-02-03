using LegalexAccount.BLL.DTO;
using LegalexAccount.BLL.Services.MailSender;
using LegalexAccount.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


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
            var specialistId = (await _unitOfWork.Specialists.AsQueryable()
                .FirstOrDefaultAsync(x => x.Email == request.Model.Email))?.Id;

            var model = request.Model.ToModel();
            model.Id = specialistId ?? default;

            await _unitOfWork.Specialists.UpdateAsync(model);
        }
    }
}
