using LegalexAccount.Utility.Types;


namespace LegalexAccount.BLL.DTO
{
    public class SpecialistDTO : UserDTO
    {
        public SpecialistRole? Role { get; set; } = null;
        public SpecialistStatus? Status { get; set; } = null;
    }
}
