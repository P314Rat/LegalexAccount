using LegalexAccount.Utility.Types;


namespace LegalexAccount.BLL.DTO
{
    public class SpecialistDTO : UserDTO
    {
        public SpecialistType? Role { get; set; } = null;
        public SpecialistStatus? Status { get; set; } = null;
    }
}
