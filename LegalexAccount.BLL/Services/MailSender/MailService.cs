using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;


namespace LegalexAccount.BLL.Services.MailSender
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;


        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        private async Task SendEmailAsync(MailRequest request)
        {
            using var email = new MimeMessage();

            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            email.To.Add(new MailboxAddress("", request.ToEmail));
            email.Subject = request.Subject;

            var builder = new BodyBuilder();

            if (request.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in request.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = request.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, true);
            await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendRegistrationDataAsync(MailRequest request, string username, string password)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Static", "Pages", "WelcomeMail.html");
            var str = new StreamReader(filePath);
            var message = str.ReadToEnd();
            str.Close();

            message = message.Replace("[username]", username).Replace("[email]", request.ToEmail).Replace("[password]", password);
            request.Body = message;

            await SendEmailAsync(request);
        }

        public async Task SendResetPasswordLink(MailRequest request, string email)
        {


            await SendEmailAsync(request);
        }
    }
}
