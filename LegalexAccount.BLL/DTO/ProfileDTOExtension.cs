using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.BLL.DTO
{
    internal static class ProfileDTOExtension
    {
        internal static ProfileDTO ToDTO(this User model)
        {
            var profileDTO = new ProfileDTO
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            return profileDTO;
        }
    }
}
