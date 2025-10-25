using System.Security.Cryptography;
using System.Text;

namespace EVDMS.Common.Utils
{
    public static class VinGenerator
    {
        public static string GenerateVin(
            string variantName,
            int year,
            int serialNumber,
            string plantCode = "A"
        )
        {
            string wmi = "5YJ"; // Tesla
            string vds = GetVariantCode(variantName); // 5 chars
            char checkDigit = 'X';
            char yearCode = GetYearCode(year);
            string serial = serialNumber.ToString("D6");
            // VIN: WMI (3) + VDS (5) + Check (1) + Year (1) + Plant (1) + Serial (6) = 17
            return $"{wmi}{vds}{checkDigit}{yearCode}{plantCode}{serial}";
        }

        // Map year to VIN year code (position 10)
        private static char GetYearCode(int year)
        {
            // VIN year codes for 1980-2039
            const string codes = "ABCDEFGHJKLMNPRSTVWXY123456789ABCDEFGHJKLMNPRSTVWXY";
            int baseYear = 1980;
            int index = year - baseYear;
            if (index < 0 || index >= codes.Length)
                return 'X';
            return codes[index];
        }

        // Deterministic 5-char code from variant name
        public static string GetVariantCode(string variantName)
        {
            if (string.IsNullOrWhiteSpace(variantName))
                return "XXXXX";
            string normalized = variantName.Trim().ToUpperInvariant().Replace(" ", "");
            byte[] hash = MD5.HashData(Encoding.UTF8.GetBytes(normalized));
            StringBuilder sb = new();
            foreach (byte b in hash)
                sb.Append(b.ToString("X2"));
            return sb.ToString()[..5]; // First 5 hex chars
        }
    }
}
