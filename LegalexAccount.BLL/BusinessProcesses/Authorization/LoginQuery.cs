using LegalexAccount.BLL.DTO;
using LegalexAccount.Utility.Types;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class LoginQuery : IRequest<UserRole>
    {
        public IdentityDTO Model { get; set; }


        public LoginQuery(IdentityDTO model)
        {
            Model = model;
        }
    }
}
