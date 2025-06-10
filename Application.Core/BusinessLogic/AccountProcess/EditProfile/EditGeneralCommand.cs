using Application.Core.DTO;
using MediatR;


namespace Application.Core.BusinessLogic.AccountProcess.EditProfile
{
    public class EditGeneralCommand : IRequest
    {
        public ProfileDTO Profile { get; set; }


        public EditGeneralCommand(ProfileDTO profile)
        {
            Profile = profile;
        }
    }
}
