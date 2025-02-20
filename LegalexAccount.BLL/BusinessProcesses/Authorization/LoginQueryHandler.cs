﻿using LegalexAccount.DAL;
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
            var user = await _unitOfWork.Users.GetByEmailAsync(request.model.Email);
            var hashedPassword = GenerateDataService.GenerateHash(request.model.Password, user.PasswordSalt);

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
