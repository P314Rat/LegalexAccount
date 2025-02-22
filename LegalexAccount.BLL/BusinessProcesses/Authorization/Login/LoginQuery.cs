using LegalexAccount.BLL.DTO;
using LegalexAccount.Utility.Types;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.Authorization.Login
{
    public class LoginQuery : IRequest<UserRole>
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public LoginQuery(AccountDTO? model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Email = model.Email ?? string.Empty;
            Password = model.Password ?? string.Empty;
        }
    }
}
