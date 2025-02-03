namespace LegalexAccount.BLL.Services.MailSender
{
    public interface IMailService
    {
        Task SendRegistrationDataAsync(MailRequest request, string username, string password);
        Task SendResetPasswordLink(MailRequest request, string email);
    }
}
