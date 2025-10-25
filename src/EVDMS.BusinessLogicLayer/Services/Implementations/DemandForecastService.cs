using System.Collections.Concurrent;
using System.Globalization;
using System.IO;
using EVDMS.BusinessLogicLayer.Models;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.ML;

public class DemandForecastService : IDemandForecastService
{
    private readonly IDealerOrderRepository _dealerOrderRepository;
    private readonly ILogger<DemandForecastService> _logger;
    private static readonly ConcurrentDictionary<string, ITransformer> _modelCache = new();
    private const string ModelDirectory = "ModelStorage";

    public DemandForecastService(
        IDealerOrderRepository dealerOrderRepository,
        ILogger<DemandForecastService> logger
    )
    {
        _dealerOrderRepository = dealerOrderRepository;
        _logger = logger;
    }

    public async Task<VariantForecastResult?> ForecastVariantAsync(Guid variantId, int horizon = 14)
    {
        var mlContext = new MLContext();
        var orders = await _dealerOrderRepository.FindAsync(o => o.VariantId == variantId);

        var history = orders
            .OrderBy(o => o.CreatedAt)
            .Select(o => new DealerOrderHistory { CreatedAt = o.CreatedAt, Quantity = o.Quantity })
            .ToList();

        int windowSize = 7;
        if (history.Count < 2 * windowSize)
            return null;

        string cacheKey =
            $"{variantId}-{history.Count}-{history.Last().CreatedAt.Ticks}-h{horizon}";
        string modelPath = Path.Combine(ModelDirectory, $"{cacheKey}.zip");
        string metaPath = Path.Combine(ModelDirectory, $"{cacheKey}.meta");

        ITransformer? model = null;
        DateTime trainedOn = DateTime.UtcNow;

        if (_modelCache.TryGetValue(cacheKey, out var cachedModel))
        {
            _logger.LogInformation("Using cached model for cacheKey: {CacheKey}", cacheKey);
            model = cachedModel;
            // Try to load trainedOn from meta file if exists
            if (File.Exists(metaPath))
            {
                var metaContent = File.ReadAllText(metaPath);
                if (
                    DateTime.TryParse(
                        metaContent,
                        null,
                        DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal,
                        out var metaDate
                    )
                )
                    trainedOn = metaDate;
            }
        }
        else if (File.Exists(modelPath))
        {
            Directory.CreateDirectory(ModelDirectory);
            using (
                var fileStream = new FileStream(
                    modelPath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read
                )
            )
            {
                model = mlContext.Model.Load(fileStream, out var _);
                if (model == null)
                {
                    _logger.LogError(
                        "Failed to load model from disk for cacheKey: {CacheKey}",
                        cacheKey
                    );
                    return null;
                }
            }
            // Load trainedOn from meta file
            if (File.Exists(metaPath))
            {
                var metaContent = File.ReadAllText(metaPath);
                if (
                    DateTime.TryParse(
                        metaContent,
                        null,
                        System.Globalization.DateTimeStyles.AdjustToUniversal
                            | System.Globalization.DateTimeStyles.AssumeUniversal,
                        out var metaDate
                    )
                )
                    trainedOn = metaDate;
            }
            _logger.LogInformation("Loaded model from disk for cacheKey: {CacheKey}", cacheKey);
            _modelCache[cacheKey] = model;
        }
        else
        {
            _logger.LogInformation("Training new model for cacheKey: {CacheKey}", cacheKey);
            var data = mlContext.Data.LoadFromEnumerable(history);
            var pipeline = mlContext.Forecasting.ForecastBySsa(
                outputColumnName: nameof(ForecastResult.ForecastedQuantity),
                inputColumnName: nameof(DealerOrderHistory.Quantity),
                windowSize: windowSize,
                seriesLength: Math.Min(30, history.Count),
                trainSize: history.Count,
                horizon: horizon
            );
            model = pipeline.Fit(data);
            Directory.CreateDirectory(ModelDirectory);
            using (
                var fileStream = new FileStream(
                    modelPath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.Write
                )
            )
            {
                mlContext.Model.Save(model, data.Schema, fileStream);
            }
            // Save trainedOn to meta file as UTC
            trainedOn = DateTime.UtcNow;
            File.WriteAllText(metaPath, trainedOn.ToString("o"));
            _logger.LogInformation("Saved model to disk for cacheKey: {CacheKey}", cacheKey);
            _modelCache[cacheKey] = model;
        }

        if (model == null)
        {
            _logger.LogError(
                "Model is null after all loading/training attempts for cacheKey: {CacheKey}",
                cacheKey
            );
            return null;
        }

        var forecastEngine = model.Transform(mlContext.Data.LoadFromEnumerable(history));
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
                TrainedOn = trainedOn,
                Algorithm = "SSA Forecasting",
            },
        };
    }
}
