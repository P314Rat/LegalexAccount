using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization
{
    public class LoginQuery : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public LoginQuery(UserDTO model)
        {
            Email = model.Email ?? string.Empty;
            Password = model.Password ?? string.Empty;
        }
    }
}
