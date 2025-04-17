using Application.Core.DTO;
using MediatR;


namespace Application.Core.BusinessLogic.ProfileProcess.GetShortProfile
{
    public class GetShortProfileQuery : IRequest<ProfileDTO>
    {
        public string Email { get; set; }


        public GetShortProfileQuery(string email)
        {
            Email = email;
        }
    }
}
