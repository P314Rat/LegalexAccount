using LegalexAccount.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class GetEmailByTokenQueryHandler : IRequestHandler<GetEmailByTokenQuery, string?>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetEmailByTokenQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string?> Handle(GetEmailByTokenQuery request, CancellationToken cancellationToken)
        {
            var email = (await _unitOfWork.PasswordResetTokens.AsQueryable()
                .FirstOrDefaultAsync(x => x.Token == request.Token))?.Email;

            return email;
        }
    }
}
