using System.Net.Mail;
using DnsClient;

namespace EVDMS.Common.Utils
{
    public static class EmailVerifier
    {
        private static readonly LookupClient _lookup = new();

        public static bool IsValidFormat(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> DomainHasMailServerAsync(string email)
        {
            try
            {
                var domain = email.Split('@').Last();
                var result = await _lookup.QueryAsync(domain, QueryType.MX);
                if (result.Answers.MxRecords().Any())
                    return true;

                // fallback to A/AAAA records
                var aResult = await _lookup.QueryAsync(domain, QueryType.A);
                if (aResult.Answers.ARecords().Any())
                    return true;

                var aaaaResult = await _lookup.QueryAsync(domain, QueryType.AAAA);
                if (aaaaResult.Answers.AaaaRecords().Any())
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        // Very small built-in disposable / blocked domains list. Extend as needed.
        // Includes common disposable providers and reserved example domains which should be rejected.
        private static readonly string[] DisposableDomains =
        [
            // disposable providers
            "mailinator.com",
            "10minutemail.com",
            "tempmail.com",
            "dispostable.com",
            "guerrillamail.com",
            "trashmail.com",
            // reserved / example domains that are not real user mailboxes
            "example.com",
            "example.org",
            "example.net",
            "localhost",
            "invalid",
            "test",
        ];

        public static bool IsDisposableDomain(string email)
        {
            try
            {
                var domain = email.Split('@').Last().ToLowerInvariant();
                // match exact domain or subdomains (e.g. sub.mailinator.com)
                foreach (var blocked in DisposableDomains)
                {
                    if (domain == blocked)
                        return true;
                    if (domain.EndsWith("." + blocked))
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
