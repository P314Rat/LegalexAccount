using LegalexAccount.BLL.DTO;
using LegalexAccount.Utility.Types;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class LoginQuery : IRequest<UserRole>
    {
        public IdentityDTO model { get; set; }


        public LoginQuery(IdentityDTO model)
        {
            this.model = model;
        }
    }
}
