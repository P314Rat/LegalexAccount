using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.BLL.DTO
{
    internal static class LegalDTOExtension
    {
        internal static Legal ToModel(this LegalDTO model)
        {
            var legalModel = new Legal
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                OrganizationName = model.OrganizationName,
                LegalAddress = model.LegalAddress,
                PostalAddress = model.PostalAddress,
                LegalID = model.LegalID,
                BankAccountNumber = model.BankAccountNumber,
                BankName = model.BankName,
                BankAddress = model.BankAddress,
                BankIdentificationCode = model.BankIdentificationCode,
                PositionHeld = model.PositionHeld,
                Powers = model.Powers
            };

            return legalModel;
        }

        internal static LegalDTO ToDTO(this Legal model)
        {
            var legalDTO = new LegalDTO
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                OrganizationName = model.OrganizationName,
                LegalAddress = model.LegalAddress,
                PostalAddress = model.PostalAddress,
                LegalID = model.LegalID,
                BankAccountNumber = model.BankAccountNumber,
                BankName = model.BankName,
                BankAddress = model.BankAddress,
                BankIdentificationCode = model.BankIdentificationCode,
                PositionHeld = model.PositionHeld,
                Powers = model.Powers
            };

            return legalDTO;
        }
    }
}
