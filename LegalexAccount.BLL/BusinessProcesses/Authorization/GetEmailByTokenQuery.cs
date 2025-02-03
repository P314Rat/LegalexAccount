using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class GetEmailByTokenQuery : IRequest<string?>
    {
        public string Token { get; set; }


        public GetEmailByTokenQuery(string token)
        {
            Token = token;
        }
    }
}
