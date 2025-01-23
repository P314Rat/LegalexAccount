using LegalexAccount.BLL.DTO;


namespace LegalexAccount.Web.ViewModels
{
    internal static class LegalViewModelExtension
    {
        internal static LegalViewModel ToViewModel(this LegalDTO model)
        {
            var viewModel = new LegalViewModel
            {
                Email = model.Email ?? string.Empty,
                Phone = model.PhoneNumber,
                FirstName = model.FirstName ?? string.Empty,
                LastName = model.LastName ?? string.Empty,
                SurName = model.SurName,
                Password = model.Password ?? string.Empty,
                OrganizationName = model.OrganizationName ?? string.Empty,
                LegalAddress = model.LegalAddress ?? string.Empty,
                PostalAddress = model.PostalAddress,
                LegalID = model.LegalID ?? string.Empty,
                BankAccountNumber = model.BankAccountNumber ?? string.Empty,
                BankName = model.BankName ?? string.Empty,
                BankAddress = model.BankAddress ?? string.Empty,
                BankIdenticationCode = model.BankIdenticationCode ?? string.Empty,
                PositionHeld = model.PositionHeld ?? string.Empty,
                Powers = model.Powers ?? string.Empty
            };

            return viewModel;
        }

        internal static LegalDTO ToDTO(this LegalViewModel model)
        {
            var modelDTO = new LegalDTO
            {
                Email = model.Email,
                PhoneNumber = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                Password = model.Password,
                OrganizationName = model.OrganizationName,
                LegalAddress = model.LegalAddress,
                PostalAddress = model.PostalAddress,
                LegalID = model.LegalID,
                BankAccountNumber = model.BankAccountNumber,
                BankName = model.BankName,
                BankAddress = model.BankAddress,
                BankIdenticationCode = model.BankIdenticationCode,
                PositionHeld = model.PositionHeld,
                Powers = model.Powers
            };

            return modelDTO;
        }
    }
}
