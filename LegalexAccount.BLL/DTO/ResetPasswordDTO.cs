namespace LegalexAccount.BLL.DTO
{
    public class ResetPasswordDTO
    {
        public string? Email { get; set; } = null;
        public string? NewPassword { get; set; } = null;
        public string? RepeatPassword { get; set; } = null;
    }
}
