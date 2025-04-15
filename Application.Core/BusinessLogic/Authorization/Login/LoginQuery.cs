using Application.Core.DTO;
using MediatR;


namespace Application.Core.BusinessLogic.Authorization.Login
{
    public class LoginQuery : IRequest<IEnumerable<string>>
    {
        public LoginDTO Model { get; set; }


        public LoginQuery(LoginDTO model)
        {
            Model = model;
        }
    }
}
