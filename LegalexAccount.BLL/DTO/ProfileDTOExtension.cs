using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.BLL.DTO
{
    internal static class ProfileDTOExtension
    {
        internal static ProfileDTO ToProfileDTO(this User model)
        {
            var profileDTO = new ProfileDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            return profileDTO;
        }
    }
}
