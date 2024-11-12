using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.Utility.Services;


namespace LegalexAccount.BLL.DTO
{
    internal static class PersonDTOExtension
    {
        internal static Person ToModel(this PersonDTO model)
        {
            const int SALT_SIZE = 32;
            var salt = GenerateDataService.CreateSalt(SALT_SIZE);

            var resultModel = new Person
            {
                Email = model.Email ?? string.Empty,
                Phone = model.Phone,
                FirstName = model.FirstName ?? string.Empty,
                LastName = model.LastName ?? string.Empty,
                SurName = model.SurName,
                PasswordHash = model.Password != null
                    ? GenerateDataService.GenerateHash(model.Password, salt)
                    : throw new Exception("Password is empty"),
                PasswordSalt = salt,
                DateOfBirth = model.DateOfBirth ?? DateTime.Now,
                PassportNumber = model.PassportNumber ?? string.Empty,
                IssuingAuthority = model.IssuingAuthority ?? string.Empty,
                IssueDate = model.IssueDate ?? DateTime.Now,
                TaxIdentificationNumber = model.TaxIdentificationNumber,
                RegistrationAddress = model.RegistrationAddress ?? string.Empty,
                ResidentialAddress = model.ResidentialAddress
            };

            return resultModel;
        }

        internal static PersonDTO ToDTO(this Person model)
        {
            var resultModel = new PersonDTO
            {
                Email = model.Email,
                Phone = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                DateOfBirth = model.DateOfBirth,
                PassportNumber = model.PassportNumber,
                IssuingAuthority = model.IssuingAuthority,
                IssueDate = model.IssueDate,
                TaxIdentificationNumber = model.TaxIdentificationNumber,
                RegistrationAddress = model.RegistrationAddress,
                ResidentialAddress = model.ResidentialAddress
            };

            return resultModel;
        }
    }
}
