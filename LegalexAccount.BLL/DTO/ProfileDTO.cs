namespace LegalexAccount.BLL.DTO
{
    public class ProfileDTO
    {
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? SurName { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? PhoneNumber { get; set; } = null;
        public string? OldPassword { get; set; } = null;
        public string? NewPassword { get; set; } = null;
        public string? RepeatPassword { get; set; } = null;
    }
}
