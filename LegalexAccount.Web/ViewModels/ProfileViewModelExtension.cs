﻿using LegalexAccount.BLL.DTO;


namespace LegalexAccount.Web.ViewModels
{
    internal static class ProfileViewModelExtension
    {
        internal static ProfileDTO ToDTO(this ProfileViewModel model)
        {
            var profileDTO = new ProfileDTO
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            return profileDTO;
        }

        internal static ProfileViewModel ToViewModel(this ProfileDTO model)
        {
            var profileViewModel = new ProfileViewModel
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            return profileViewModel;
        }
    }
}
