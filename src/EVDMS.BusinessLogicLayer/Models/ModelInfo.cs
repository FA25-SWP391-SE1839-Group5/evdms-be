namespace EVDMS.BusinessLogicLayer.Models
{
    public class ModelInfo
    {
        public string Version { get; set; } = "1.0.0";
        public DateTime TrainedOn { get; set; }
        public string Algorithm { get; set; } = "SSA Forecasting";
    }
}
