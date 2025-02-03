using LegalexAccount.BLL.Services.MailSender;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.AccountAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Security.Cryptography;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
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

        public async Task Handle(ForgotPasswordCommand command, CancellationToken cancellationToken)
        {
            var isUserExists = await _unitOfWork.Users.IsExistsAsync(command.Email);

            if (isUserExists)
            {
                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

                var tokenModel = new PasswordResetToken
                {
                    Email = command.Email,
                    Token = token,
                    ExpiryDate = DateTime.UtcNow.AddHours(1),
                    IsUsed = false
                };

                var resetUrl = _linkGenerator.GetUriByAction(
                        action: "ResetPassword",
                        controller: "Account",
                        values: new { email = command.Email, token = token },
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
            }
        }
    }
}
