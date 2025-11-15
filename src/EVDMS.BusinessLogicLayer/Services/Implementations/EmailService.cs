using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailOptions)
        {
            _emailSettings = emailOptions.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(
                new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail)
            );
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

            using var client = new SmtpClient();
            await client.ConnectAsync(
                _emailSettings.SmtpServer,
                _emailSettings.Port,
                SecureSocketOptions.StartTls
            );
            await client.AuthenticateAsync(
                _emailSettings.SenderEmail,
                _emailSettings.SenderPassword
            );
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
