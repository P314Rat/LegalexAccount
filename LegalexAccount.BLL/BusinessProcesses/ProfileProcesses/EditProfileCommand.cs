using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ProfileProcesses
{
    public class EditProfileCommand : IRequest
    {
        public UserDTO EditableModel { get; set; }
        public UserDTO Model { get; set; }


        public EditProfileCommand(UserDTO editableModel, UserDTO model)
        {
            EditableModel = editableModel;
            Model = model;
        }
    }
}
