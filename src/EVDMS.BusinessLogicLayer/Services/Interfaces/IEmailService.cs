namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
        Task SendActionEmailAsync(
            string to,
            string subject,
            string action,
            string token,
            string htmlTemplate
        );
    }
}
