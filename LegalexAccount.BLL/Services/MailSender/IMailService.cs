namespace LegalexAccount.BLL.Services.MailSender
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
