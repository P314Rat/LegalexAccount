using LegalexAccount.BLL.DTO;
using Microsoft.AspNetCore.SignalR;

using LegalexAccount.BLL.Services;


namespace LegalexAccount.Web.ViewModels
{
    internal static class SpecialistViewModelExtension
    {
        internal static SpecialistDTO ToDTO(this SpecialistViewModel model)
        {
            var specialistDTO = new SpecialistDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Status = model.Status,
                Role = model.Role
            };

            return specialistDTO;
        }

        internal static SpecialistViewModel ToViewModel(this SpecialistDTO model, PresenceTrackerService presenceTracker)
        {
            var specialistViewModel = new SpecialistViewModel
            {
                IsOnline = model.Email != null ? presenceTracker.IsOnline(model.Email) : false,
                FirstName = model.FirstName ?? string.Empty,
                LastName = model.LastName ?? string.Empty,
                SurName = model.SurName,
                Email = model.Email ?? string.Empty,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password ?? string.Empty,
                Status = model.Status ?? Utility.Types.SpecialistStatus.Free,
                Role = model.Role ?? Utility.Types.SpecialistType.Specialist
            };

            return specialistViewModel;
        }
    }
}
