using LegalexAccount.Utility.Types;


namespace LegalexAccount.BLL.DTO
{
    public class SpecialistDTO : UserDTO
    {
        public SpecialistRole Role { get; set; }
        public SpecialistStatus Status { get; set; }
    }
}
