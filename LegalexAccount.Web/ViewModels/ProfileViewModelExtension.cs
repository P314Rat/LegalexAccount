using LegalexAccount.BLL.DTO;


namespace LegalexAccount.Web.ViewModels
{
    internal static class ProfileViewModelExtension
    {
        internal static ProfileViewModel ToViewModel(this ProfileDTO model)
        {
            var profileViewModel = new ProfileViewModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            return profileViewModel;
        }

        internal static ProfileDTO ToDTO(this ProfileViewModel model)
        {
            var profileDTO = new ProfileDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            return profileDTO;
        }
    }
}
