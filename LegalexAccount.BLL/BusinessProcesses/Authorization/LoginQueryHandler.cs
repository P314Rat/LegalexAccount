using LegalexAccount.Utility.Services;
using LegalexAccount.DAL.Models;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery>
    {
        private readonly IUnitOfWork _unitOfWork;


        public LoginQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            var hashedPassword = GenerateDataService.GenerateHash(request.Password, user.PasswordSalt);

            if (user.PasswordHash != hashedPassword)
                throw new InvalidOperationException("Password is not valid");
        }
    }
}
