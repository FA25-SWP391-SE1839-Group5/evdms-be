using System.Threading.Tasks;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/forecast")]
    public class DemandForecastController : ControllerBase
    {
        private readonly IDemandForecastService _demandForecastService;
        private readonly IVehicleVariantService _vehicleVariantService;

        public DemandForecastController(
            IDemandForecastService demandForecastService,
            IVehicleVariantService vehicleVariantService
        )
        {
            _demandForecastService = demandForecastService;
            _vehicleVariantService = vehicleVariantService;
        }

        [HttpGet("{variantId}")]
        public async Task<IActionResult> GetVariantForecast(
            Guid variantId,
            [FromQuery] int horizon = 14
        )
        {
            var forecast = await _demandForecastService.ForecastVariantAsync(variantId, horizon);
            if (forecast == null)
                return NotFound(new { message = "Not enough data to forecast for this variant." });
            var variant = await _vehicleVariantService.GetByIdAsync(variantId);
            forecast.VariantName = variant?.Name ?? string.Empty;
            return Ok(
                new
                {
                    horizon = forecast.Horizon,
                    generatedAt = forecast.GeneratedAt.ToString("o"),
                    variant = forecast.VariantName,
                    forecasts = forecast.Forecasts.Select(f => new
                    {
                        step = f.Step,
                        timestamp = f.Timestamp.ToString("yyyy-MM-dd"),
                        predictedDemand = f.PredictedDemand,
                    }),
                    modelInfo = new
                    {
                        version = forecast.ModelInfo.Version,
                        trainedOn = forecast.ModelInfo.TrainedOn.ToString("o"),
                        algorithm = forecast.ModelInfo.Algorithm,
                    },
                }
            );
        }

        [HttpPost("{variantId}/retrain")]
        public async Task<IActionResult> RetrainVariantModel(
            Guid variantId,
            [FromQuery] int horizon
        )
        {
            var result = await _demandForecastService.RetrainVariantModelAsync(variantId, horizon);
            if (!result)
                return BadRequest(
                    new { message = "Not enough data to retrain model for this variant." }
                );
            return Accepted(new { message = "Model retraining started for this variant." });
        }
    }
}
