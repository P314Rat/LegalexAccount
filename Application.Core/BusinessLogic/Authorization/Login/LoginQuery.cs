using Application.Core.DTO;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.Authorization.Login
{
    public class LoginQuery : IRequest<UserRole>
    {
        public LoginDTO Model { get; set; }


        public LoginQuery(LoginDTO model)
        {
            Model = model;
        }
    }
}
