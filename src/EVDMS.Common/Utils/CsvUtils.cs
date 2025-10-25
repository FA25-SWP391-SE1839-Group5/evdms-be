namespace EVDMS.Common.Utils
{
    public class CsvExportResult
    {
        public string FileName { get; set; } = string.Empty;
        public string CsvContent { get; set; } = string.Empty;
    }

    public static class CsvUtils
    {
        public static string EscapeCsv(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            if (value.Contains(',') || value.Contains('\"'))
                return $"\"{value.Replace("\"", "\"\"")}\"";
            return value;
        }

        public static string BuildCsvFileName(
            string baseName,
            DateTime? startDate,
            DateTime? endDate,
            string? prefix = null
        )
        {
            string start = startDate.HasValue ? startDate.Value.ToString("yyyyMMdd") : "";
            string end = endDate.HasValue ? endDate.Value.ToString("yyyyMMdd") : "";
            string range = (start != "" || end != "") ? $"_{start}-{end}" : "";
            string pre = string.IsNullOrWhiteSpace(prefix) ? "" : $"{prefix}_";
            return $"{pre}{baseName}{range}_{DateTime.UtcNow:yyyyMMddHHmmss}.csv";
        }
    }
}
