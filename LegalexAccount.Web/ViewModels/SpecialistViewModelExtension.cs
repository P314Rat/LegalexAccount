using LegalexAccount.BLL.DTO;


namespace LegalexAccount.Web.ViewModels
{
    internal static class SpecialistViewModelExtension
    {
        internal static SpecialistDTO ToDTO(this SpecialistViewModel model)
        {
            var specialistDTO = new SpecialistDTO
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Status = model.Status,
                Role = model.Role
            };

            return specialistDTO;
        }

        internal static SpecialistViewModel ToViewModel(this SpecialistDTO model)
        {
            var specialistViewModel = new SpecialistViewModel
            {
                Email = model.Email ?? string.Empty,
                FirstName = model.FirstName ?? string.Empty,
                LastName = model.LastName ?? string.Empty,
                Password = model.Password ?? string.Empty,
                Role = model.Role ?? Utility.Types.SpecialistRole.Employee,
                Status = model.Status ?? Utility.Types.SpecialistStatus.Free
            };

            return specialistViewModel;
        }
    }
}
