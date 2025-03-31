using Application.Core.DTO;
using MediatR;


namespace Application.Core.BusinessLogic.AccountProcess.EditProfile
{
    public class EditProfileCommand : IRequest
    {
        public ProfileDTO Profile { get; set; }


        public EditProfileCommand(ProfileDTO profile)
        {
            Profile = profile;
        }
    }
}
