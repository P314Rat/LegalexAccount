using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<Unit>
    {
        public string Email { get; set; }


        public ForgotPasswordCommand(string? email)
        {
            Email = email ?? string.Empty;
        }
    }
}
