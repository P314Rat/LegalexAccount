using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Identification
{
    public class IdentificationQuery : IRequest<ProfileDTO>
    {
        public string Email { get; set; }


        public IdentificationQuery(string email)
        {
            Email = email;
        }
    }
}
