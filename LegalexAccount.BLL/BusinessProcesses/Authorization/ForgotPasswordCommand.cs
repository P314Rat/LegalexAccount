using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class ForgotPasswordCommand : IRequest
    {
        public string Email { get; set; }


        public ForgotPasswordCommand(string email)
        {
            Email = email;
        }
    }
}
