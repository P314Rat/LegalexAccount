using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.Utility.Services;


namespace LegalexAccount.BLL.DTO
{
    internal static class SpecialistDTOExtension
    {
        internal static Specialist ToModel(this SpecialistDTO model)
        {
            const int SALT_SIZE = 32;
            var salt = GenerateDataService.CreateSalt(SALT_SIZE);

            var resultModel = new Specialist
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
                Role = model.Role ?? Utility.Types.SpecialistRole.Employee,
                Status = model.Status ?? Utility.Types.SpecialistStatus.Free
            };

            return resultModel;
        }

        internal static SpecialistDTO ToDTO(this Specialist model)
        {
            var resultModel = new SpecialistDTO
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                Role = model.Role,
                Status = model.Status
            };

            return resultModel;
        }
    }
}
