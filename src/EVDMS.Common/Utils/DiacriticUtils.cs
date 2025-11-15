using System.Globalization;
using System.Text;

namespace EVDMS.Common.Utils
{
    public static class DiacriticUtils
    {
        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            var normalized = text.Normalize(NormalizationForm.FormD);
            var chars = normalized
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }
    }
}
