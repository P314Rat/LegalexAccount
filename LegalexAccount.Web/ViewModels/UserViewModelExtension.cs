using LegalexAccount.BLL.DTO;


namespace LegalexAccount.Web.ViewModels
{
    internal static class UserViewModelExtension
    {
        internal static UserDTO ToDTO(this UserViewModel model)
        {
            var result = new UserDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            return result;
        }

        internal static UserViewModel ToViewModel(this UserDTO model)
        {
            var result = new UserViewModel
            {
                FirstName = model.FirstName ?? string.Empty,
                LastName = model.LastName ?? string.Empty,
                SurName = model.SurName ?? string.Empty,
                Email = model.Email ?? string.Empty,
                PhoneNumber = model.PhoneNumber
            };

            return result;
        }
    }
}
