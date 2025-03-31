using Application.Core.DTO;
using MediatR;


namespace Application.Core.BusinessLogic.AccountProcess.GetProfile
{
    public class GetProfileQuery : IRequest<ProfileDTO>
    {
        public string Email { get; set; }


        public GetProfileQuery(string email)
        {
            Email = email;
        }
    }
}
