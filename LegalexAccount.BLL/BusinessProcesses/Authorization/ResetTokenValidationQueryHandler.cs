using LegalexAccount.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class ResetTokenValidationQueryHandler : IRequestHandler<ResetTokenValidationQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;


        public ResetTokenValidationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ResetTokenValidationQuery request, CancellationToken cancellationToken)
        {
            var token = await _unitOfWork.PasswordResetTokens.AsQueryable()
                .FirstOrDefaultAsync(x => x.Token == request.Token);

            if (token == null || token.IsUsed || token.ExpirationDate < DateTime.UtcNow)
                return false;

            token.IsUsed = true;
            await _unitOfWork.PasswordResetTokens.UpdateAsync(token);

            return true;
        }
    }
}
