using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ProfileProcesses
{
    public class EditProfileCommand : IRequest
    {
        public string UserEmail { get; set; }
        public ProfileDTO? Profile { get; set; }
        public ResetPasswordDTO? Password { get; set; }


        public EditProfileCommand(string userEmail, ProfileDTO? profile = null, ResetPasswordDTO? password = null)
        {
            UserEmail = userEmail;
            Profile = profile;
            Password = password;
        }
    }
}
