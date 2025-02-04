using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.BLL.DTO
{
    internal static class UserDTOExtension
    {
        internal static UserDTO ToDTO(this User model)
        {
            var userDTO = new UserDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                SurName = model.SurName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            return userDTO;
        }
    }
}
