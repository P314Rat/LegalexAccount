namespace Application.Core.Services.MailSender
{
    public interface IMailSenderService
    {
        Task SendEmailAsync(MailRequest request);
    }
}
