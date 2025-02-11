using FluentValidation;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization.ForgotPassword
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
