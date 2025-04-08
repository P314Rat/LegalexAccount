using Domain.Core.UserAggregate;
using Infrastructure.Contracts;
using Infrastructure.Specifications.UserAggregate;
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
            var user = (await _unitOfWork.Repository<User, Guid>()
                .GetAsync(new UserByEmailSpecification(request.Model.Email))).FirstOrDefault();
            var hashedPassword = GenerateDataService.GenerateHash(request.Model.Password, user.PasswordSalt);
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
