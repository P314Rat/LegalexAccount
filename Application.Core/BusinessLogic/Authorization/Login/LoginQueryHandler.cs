using Domain.Core.UserAggregate;
using Infrastructure.Specifications.UserAggregate;
using MediatR;
using System.Linq;
using Utilities.Extensions;
using Utilities.StaticServices;


namespace Application.Core.BusinessLogic.Authorization.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, IEnumerable<string>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public LoginQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = (await _unitOfWork.Repository<User, Guid>()
                .GetAsync(new UserByEmailSpecification(request.Model.Email)))
                .FirstOrDefault();
            var hashedPassword = GenerateDataService.GenerateHash(request.Model.Password, user.PasswordSalt);

            if (hashedPassword != user.PasswordHash)
                throw new Exception("Неверные данные для входа");

            List<string> roles = new List<string> { user.Role.Name };

            switch (user)
            {
                case Specialist:
                    roles.Add(((Specialist)user).SpecialistRole.Name);

                    break;

                case Client:
                    roles.Add(((Client)user).ClientRole.Name);

                    break;
            }

            return roles;
        }
    }
}
