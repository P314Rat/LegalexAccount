using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ProfileProcesses
{
    public class GetShortProfileQuery : IRequest<ShortProfileDTO?>
    {
        public string Email { get; set; }


        public GetShortProfileQuery(string email)
        {
            Email = email;
        }
    }
}
