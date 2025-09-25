using System.Net;
using System.Net.Mail;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly IConfiguration _configuration;

        public EmailService(IOptions<EmailSettings> options, IConfiguration configuration)
        {
            _settings = options.Value;
            _configuration = configuration;
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

        public async Task SendActionEmailAsync(
            string to,
            string subject,
            string action,
            string token,
            string htmlTemplate
        )
        {
            var baseUrl = _configuration["App:BaseUrl"] ?? "http://localhost:3000";
            var environment = _configuration["ASPNETCORE_ENVIRONMENT"] ?? "Production";
            var encodedToken = Uri.EscapeDataString(token);
            string link =
                environment == "Development"
                    ? $"{baseUrl}/api/auth/{action}?token={encodedToken}"
                    : $"{baseUrl}/{action}?token={encodedToken}";
            var body = string.Format(htmlTemplate, link, DateTime.UtcNow.Year);
            await SendEmailAsync(to, subject, body);
        }
    }
}
