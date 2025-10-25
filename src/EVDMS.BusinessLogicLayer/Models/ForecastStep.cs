namespace EVDMS.BusinessLogicLayer.Models
{
    public class ForecastStep
    {
        public int Step { get; set; }
        public DateTime Timestamp { get; set; }
        public float PredictedDemand { get; set; }
    }
}
