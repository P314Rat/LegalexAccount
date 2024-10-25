using LegalexAccount.DAL.Models.UserAggregate;

namespace LegalexAccount.BLL.DTO
{
    internal static class PersonDTOExtension
    {
        internal static Person ToModel(this PersonDTO model)
        {
            var personModel = new Person
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                DateOfBirth = model.DateOfBirth,
                PassportNumber = model.PassportNumber,
                IssuingAuthority = model.IssuingAuthority,
                IssueDate = model.IssueDate,
                TaxIdentificationNumber = model.TaxIdentificationNumber,
                RegistrationAddress = model.RegistrationAddress,
                ResidentialAddress = model.ResidentialAddress
            };

            return personModel;
        }

        internal static PersonDTO ToDTO(this Person model)
        {
            var personDTO = new PersonDTO
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                DateOfBirth = model.DateOfBirth,
                PassportNumber = model.PassportNumber,
                IssuingAuthority = model.IssuingAuthority,
                IssueDate = model.IssueDate,
                TaxIdentificationNumber = model.TaxIdentificationNumber,
                RegistrationAddress = model.RegistrationAddress,
                ResidentialAddress = model.ResidentialAddress
            };

            return personDTO;
        }
    }
}
