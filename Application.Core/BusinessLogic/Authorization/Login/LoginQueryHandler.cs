using Domain.Core.UserAggregate;
using Infrastructure;
using MediatR;
using Utilities.StaticServices;
using Utilities.Types;


namespace Application.Core.BusinessLogic.Authorization.Login
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
            var user = await _unitOfWork.Users.GetAsync(request.Email);

            if (user == null)
                throw new Exception("Invalid Email");

            var hashedPassword = GenerateDataService.GenerateHash(request.Password, user.PasswordSalt);

            if (user.PasswordHash != hashedPassword)
                throw new Exception("Invalid Password");

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
