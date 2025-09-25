using System.Net;
using System.Net.Mail;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Settings;
using Microsoft.Extensions.Options;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using var client = new SmtpClient(_settings.SmtpServer, _settings.Port)
            {
                Credentials = new NetworkCredential(
                    _settings.SenderEmail,
                    _settings.SenderPassword
                ),
                EnableSsl = true,
            };
            var mail = new MailMessage
            {
                From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mail.To.Add(to);
            await client.SendMailAsync(mail);
        }
    }
}
