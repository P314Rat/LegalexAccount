using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.BLL.DTO
{
    internal static class SpecialistDTOExtension
    {
        internal static Specialist ToModel(this SpecialistDTO model)
        {
            var specialist = new Specialist
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                Role = model.Role,
                Status = model.Status
            };

            return specialist;
        }

        internal static SpecialistDTO ToDTO(this Specialist model)
        {
            var specialistDTO = new SpecialistDTO
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                Role = model.Role,
                Status = model.Status
            };

            return specialistDTO;
        }
    }
}
