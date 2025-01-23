using LegalexAccount.BLL.DTO;


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
                PhoneNumber = model.Phone,
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
                FirstName = model.FirstName ?? string.Empty,
                LastName = model.LastName ?? string.Empty,
                SurName = model.SurName,
                Email = model.Email ?? string.Empty,
                Phone = model.PhoneNumber,
                Password = model.Password ?? string.Empty,
                Status = model.Status ?? Utility.Types.SpecialistStatus.Free,
                Role = model.Role ?? Utility.Types.SpecialistRole.Employee
            };

            return specialistViewModel;
        }
    }
}
