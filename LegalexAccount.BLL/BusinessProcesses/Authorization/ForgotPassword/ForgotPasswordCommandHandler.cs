using LegalexAccount.BLL.Services.MailSender;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.AccountAggregate;
using LegalexAccount.Utility.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Security.Cryptography;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;
        private readonly LinkGenerator _linkGenerator;


        public ForgotPasswordCommandHandler(IUnitOfWork unitOfWork, IMailService mailService, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
            _linkGenerator = linkGenerator;
        }

        public async Task<Unit> Handle(ForgotPasswordCommand command, CancellationToken cancellationToken)
        {
            var isUserExists = await _unitOfWork.Users.IsExistsAsync(command.Email);

            if (!isUserExists)
                throw new ValidationException("Email", "Неверная электронная почта");

            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

            var tokenModel = new PasswordResetToken
            {
                Email = command.Email,
                Token = token,
                ExpirationDate = DateTime.UtcNow.AddMinutes(4),
                IsUsed = false
            };

            await _unitOfWork.PasswordResetTokens.CreateAsync(tokenModel);

            var resetUrl = _linkGenerator.GetUriByAction(
                    action: "ResetPassword",
                    controller: "Account",
                    values: new { token },
                    scheme: "https",
                    host: new HostString("account.legalex.by")
                );

            var message = new MailRequest
            {
                ToEmail = command.Email,
                Subject = "Password reset",
                Body = resetUrl ?? string.Empty
            };

            await _mailService.SendResetPasswordLink(message, command.Email);

            return Unit.Value;
        }
    }
}
