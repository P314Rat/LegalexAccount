using Application.Core.DTO.LoginObject;
using MediatR;
using Utilities.Types;


namespace Application.Core.BusinessLogic.Authorization.Login
{
    public class LoginQuery : IRequest<UserRole>
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public LoginQuery(LoginDTO model)
        {
            Email = model.Email ?? string.Empty;
            Password = model.Password ?? string.Empty;
        }
    }
}
