using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.UserAggregate;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using LegalexAccount.BLL.Services;


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
            var user = _unitOfWork.Users.GetByEmail(request.Email);

            if (user == null)
                throw new InvalidOperationException("Email is not valid");

            var hashedPassword = GenerateDataService.GenerateHash(request.Password, user.PasswordSalt);

            if (user.PasswordHash != hashedPassword)
                throw new InvalidOperationException("Password is not valid");
        }
    }
}
