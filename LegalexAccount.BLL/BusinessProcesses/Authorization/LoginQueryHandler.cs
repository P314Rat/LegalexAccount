using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.Utility.Services;
using LegalexAccount.Utility.Types;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, UserRole>
    {
        private readonly IUnitOfWork _unitOfWork;


        public LoginQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserRole> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var email = request.Model?.Email;

            if (email == null)
                throw new ArgumentNullException(nameof(email) + " email");

            var user = await _unitOfWork.Users.GetByEmailAsync(email);

            if (user == null)
                throw new Exception("Email is not valid");

            var password = request.Model?.Password;

            if (password == null)
                throw new ArgumentNullException(nameof(password) + " password");

            var hashedPassword = GenerateDataService.GenerateHash(password, user.PasswordSalt);

            if (user.PasswordHash != hashedPassword)
                throw new InvalidOperationException("Password is not valid");

            var userRole = user switch
            {
                Specialist => (UserRole)((Specialist)user).Role,
                Client => UserRole.Client,
                _ => throw new InvalidOperationException("Unknown user type")
            };

            return userRole;
        }
    }
}
