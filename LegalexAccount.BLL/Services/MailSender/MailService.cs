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

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(basePath, "Static", "Pages", "WelcomeMail.html");

            StreamReader str = new StreamReader(filePath);
            string MailText = str.ReadToEnd();
            str.Close();

            MailText = MailText.Replace("[username]", "Юзернейм").Replace("[email]", mailRequest.ToEmail).Replace("[password]", "Пароль");

            using var email = new MimeMessage();

            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            email.To.Add(new MailboxAddress("", mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
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

            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, true);
            await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
    }
}
