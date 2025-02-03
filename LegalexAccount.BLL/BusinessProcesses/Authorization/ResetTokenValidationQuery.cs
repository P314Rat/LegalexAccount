using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class ResetTokenValidationQuery : IRequest<bool>
    {
        public string Token { get; set; }


        public ResetTokenValidationQuery(string token)
        {
            Token = token;
        }
    }
}
