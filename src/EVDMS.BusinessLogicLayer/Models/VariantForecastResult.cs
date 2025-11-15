namespace EVDMS.BusinessLogicLayer.Models
{
    public class VariantForecastResult
    {
        public Guid VariantId { get; set; }
        public string VariantName { get; set; } = string.Empty;
        public int Horizon { get; set; }
        public DateTime GeneratedAt { get; set; }
        public List<ForecastStep> Forecasts { get; set; } = new();
        public ModelInfo ModelInfo { get; set; } = new();
    }
}
