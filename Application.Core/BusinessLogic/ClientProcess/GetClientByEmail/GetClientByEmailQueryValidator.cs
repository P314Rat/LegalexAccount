using FluentValidation;


namespace Application.Core.BusinessLogic.ClientProcess.GetClientByEmail
{
    public class GetClientByEmailQueryValidator : AbstractValidator<GetClientByEmailQuery>
    {
        public GetClientByEmailQueryValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
}
