using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ProfileProcesses
{
    public class EditProfileCommand : IRequest
    {
        public string UserEmail { get; set; }
        public ProfileDTO Model { get; set; }


        public EditProfileCommand(string userEmail, ProfileDTO model)
        {
            UserEmail = userEmail;
            Model = model;
        }
    }
}
