using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.Utility.Services;


namespace LegalexAccount.BLL.DTO
{
    internal static class LegalDTOExtension
    {
        internal static Legal ToModel(this LegalDTO model)
        {
            const int SALT_SIZE = 32;
            var salt = GenerateDataService.CreateSalt(SALT_SIZE);

            var resultModel = new Legal
            {
                Email = model.Email ?? string.Empty,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName ?? string.Empty,
                LastName = model.LastName ?? string.Empty,
                SurName = model.SurName,
                PasswordHash = model.Password != null
                    ? GenerateDataService.GenerateHash(model.Password, salt)
                    : throw new Exception("Password is empty"),
                PasswordSalt = salt,
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

            return resultModel;
        }

        internal static LegalDTO ToDTO(this Legal model)
        {
            var resultModel = new LegalDTO
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
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

            return resultModel;
        }
    }
}
