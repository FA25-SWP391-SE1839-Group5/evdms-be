using EVDMS.BusinessLogicLayer.Models;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.ML;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class DemandForecastService : IDemandForecastService
    {
        private readonly IDealerOrderRepository _dealerOrderRepository;

        public DemandForecastService(IDealerOrderRepository dealerOrderRepository)
        {
            _dealerOrderRepository = dealerOrderRepository;
        }

        public async Task<VariantForecastResult?> ForecastVariantAsync(
            Guid variantId,
            int horizon = 14
        )
        {
            var mlContext = new MLContext();
            var orders = await _dealerOrderRepository.FindAsync(o => o.VariantId == variantId);
            var history = orders
                .OrderBy(o => o.CreatedAt)
                .Select(o => new DealerOrderHistory
                {
                    CreatedAt = o.CreatedAt,
                    Quantity = o.Quantity,
                })
                .ToList();

            if (history.Count < 1)
                return null;

            // Dynamically set windowSize based on available data
            int minWindow = 2;
            int windowSize = Math.Max(minWindow, Math.Min(7, history.Count / 2 - 1));
            if (history.Count <= 2 * windowSize)
                windowSize = Math.Max(minWindow, history.Count / 2);
            if (windowSize < minWindow || history.Count <= 2 * windowSize)
                windowSize = minWindow;

            var data = mlContext.Data.LoadFromEnumerable(history);
            var pipeline = mlContext.Forecasting.ForecastBySsa(
                outputColumnName: nameof(ForecastResult.ForecastedQuantity),
                inputColumnName: nameof(DealerOrderHistory.Quantity),
                windowSize: windowSize,
                seriesLength: 30,
                trainSize: history.Count,
                horizon: horizon
            );
            var model = pipeline.Fit(data);

            // Create a forecast using the model's Transform method
            var forecastEngine = model.Transform(data);
            var forecastResult = mlContext
                .Data.CreateEnumerable<ForecastResult>(forecastEngine, reuseRowObject: false)
                .LastOrDefault();

            if (forecastResult == null || forecastResult.ForecastedQuantity == null)
                return null;

            var forecasts = new List<ForecastStep>();
            var lastHistory = history.Last();
            var startDate = lastHistory.CreatedAt.Date.AddDays(1);
            for (int i = 0; i < forecastResult.ForecastedQuantity.Length; i++)
            {
                forecasts.Add(
                    new ForecastStep
                    {
                        Step = i + 1,
                        Timestamp = startDate.AddDays(i),
                        PredictedDemand = (float)Math.Round(forecastResult.ForecastedQuantity[i]),
                    }
                );
            }

            return new VariantForecastResult
            {
                VariantId = variantId,
                Horizon = horizon,
                GeneratedAt = DateTime.UtcNow,
                Forecasts = forecasts,
                ModelInfo = new ModelInfo
                {
                    Version = "1.0.0",
                    TrainedOn = history.Last().CreatedAt.Date,
                    Algorithm = "SSA Forecasting",
                },
            };
        }
    }
}
