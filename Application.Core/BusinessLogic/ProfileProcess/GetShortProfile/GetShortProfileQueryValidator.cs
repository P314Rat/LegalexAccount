using FluentValidation;


namespace Application.Core.BusinessLogic.ProfileProcess.GetShortProfile
{
    public class GetShortProfileQueryValidator : AbstractValidator<GetShortProfileQuery>
    {
        public GetShortProfileQueryValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
}
