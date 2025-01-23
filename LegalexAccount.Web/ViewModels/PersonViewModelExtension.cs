using LegalexAccount.BLL.DTO;


namespace LegalexAccount.Web.ViewModels
{
    internal static class PersonViewModelExtension
    {
        internal static PersonViewModel ToViewModel(this PersonDTO model)
        {
            var viewModel = new PersonViewModel
            {
                Email = model.Email ?? string.Empty,
                Phone = model.PhoneNumber,
                FirstName = model.FirstName ?? string.Empty,
                LastName = model.LastName ?? string.Empty,
                SurName = model.SurName,
                Password = model.Password ?? string.Empty,
                DateOfBirth = model.DateOfBirth ?? DateTime.Now,
                PassportNumber = model.PassportNumber ?? string.Empty,
                IssuingAuthority = model.IssuingAuthority ?? string.Empty,
                IssueDate = model.IssueDate ?? DateTime.Now,
                TaxIdentificationNumber = model.TaxIdentificationNumber,
                RegistrationAddress = model.RegistrationAddress ?? string.Empty,
                ResidentialAddress = model.ResidentialAddress
            };

            return viewModel;
        }

        internal static PersonDTO ToDTO(this PersonViewModel model)
        {
            var modelDTO = new PersonDTO
            {
                Email = model.Email,
                PhoneNumber = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                Password = model.Password,
                DateOfBirth = model.DateOfBirth,
                PassportNumber = model.PassportNumber,
                IssuingAuthority = model.IssuingAuthority,
                IssueDate = model.IssueDate,
                TaxIdentificationNumber = model.TaxIdentificationNumber,
                RegistrationAddress = model.RegistrationAddress,
                ResidentialAddress = model.ResidentialAddress
            };

            return modelDTO;
        }
    }
}
