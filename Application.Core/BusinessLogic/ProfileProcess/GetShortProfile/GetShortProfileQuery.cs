using Application.Core.DTO.UserObject;
using MediatR;


namespace Application.Core.BusinessLogic.ProfileProcess.GetShortProfile
{
    public class GetShortProfileQuery : IRequest<UserDTO?>
    {
        public string Email { get; set; }

        public GetShortProfileQuery(string email)
        {
            Email = email;
        }
    }
}
