using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ProfileProcesses
{
    public class GetProfileQuery : IRequest<ProfileDTO?>
    {
        public string Email { get; set; }


        public GetProfileQuery(string email)
        {
            Email = email;
        }
    }
}
