using System.Collections.Concurrent;
using System.Globalization;
using System.IO;
using EVDMS.BusinessLogicLayer.Models;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;

public class DemandForecastService : IDemandForecastService
{
    private readonly IDealerOrderRepository _dealerOrderRepository;
    private readonly ILogger<DemandForecastService> _logger;
    private static readonly ConcurrentDictionary<string, ITransformer> _modelCache = new();
    private const string ModelDirectory = "ModelStorage";
    private const int WindowSize = 7;

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
        var history = await GetOrderHistoryAsync(variantId);
        if (history.Count < 2 * WindowSize)
            return null;
        string cacheKey = BuildCacheKey(variantId, history, horizon);
        string modelPath = Path.Combine(ModelDirectory, $"{cacheKey}.zip");
        string metaPath = Path.Combine(ModelDirectory, $"{cacheKey}.meta");
        DateTime trainedOn = DateTime.UtcNow;
        ITransformer? model;
        if (_modelCache.TryGetValue(cacheKey, out var cachedModel))
        {
            _logger.LogInformation("Using cached model for cacheKey: {CacheKey}", cacheKey);
            model = cachedModel;
            trainedOn = LoadTrainedOn(metaPath, trainedOn);
        }
        else if (File.Exists(modelPath))
        {
            Directory.CreateDirectory(ModelDirectory);
            model = LoadModel(mlContext, modelPath);
            if (model == null)
                return null;
            trainedOn = LoadTrainedOn(metaPath, trainedOn);
            _logger.LogInformation("Loaded model from disk for cacheKey: {CacheKey}", cacheKey);
            _modelCache[cacheKey] = model;
        }
        else
        {
            _logger.LogInformation("Training new model for cacheKey: {CacheKey}", cacheKey);
            model = TrainAndSaveModel(mlContext, history, cacheKey, horizon);
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

    public async Task<bool> RetrainVariantModelAsync(Guid variantId, int horizon)
    {
        var mlContext = new MLContext();
        var history = await GetOrderHistoryAsync(variantId);
        if (history.Count < 2 * WindowSize)
            return false;
        string cacheKey = BuildCacheKey(variantId, history, horizon);
        string modelPath = Path.Combine(ModelDirectory, $"{cacheKey}.zip");
        string metaPath = Path.Combine(ModelDirectory, $"{cacheKey}.meta");
        DeleteModelFiles(modelPath, metaPath);
        _modelCache.TryRemove(cacheKey, out _);
        var model = TrainAndSaveModel(mlContext, history, cacheKey, horizon);
        var trainedOn = DateTime.UtcNow;
        File.WriteAllText(metaPath, trainedOn.ToString("o"));
        _modelCache[cacheKey] = model;
        _logger.LogInformation("Model retrained and saved for cacheKey: {CacheKey}", cacheKey);
        return true;
    }

    private async Task<List<DealerOrderHistory>> GetOrderHistoryAsync(Guid variantId)
    {
        var orders = await _dealerOrderRepository.FindAsync(o => o.VariantId == variantId);
        return orders
            .OrderBy(o => o.CreatedAt)
            .Select(o => new DealerOrderHistory { CreatedAt = o.CreatedAt, Quantity = o.Quantity })
            .ToList();
    }

    private static string BuildCacheKey(
        Guid variantId,
        List<DealerOrderHistory> history,
        int horizon
    )
    {
        return $"{variantId}-{history.Count}-{history.Last().CreatedAt.Ticks}-h{horizon}";
    }

    private static SsaForecastingTransformer TrainAndSaveModel(
        MLContext mlContext,
        List<DealerOrderHistory> history,
        string cacheKey,
        int horizon
    )
    {
        var data = mlContext.Data.LoadFromEnumerable(history);
        var pipeline = mlContext.Forecasting.ForecastBySsa(
            outputColumnName: nameof(ForecastResult.ForecastedQuantity),
            inputColumnName: nameof(DealerOrderHistory.Quantity),
            windowSize: WindowSize,
            seriesLength: Math.Min(30, history.Count),
            trainSize: history.Count,
            horizon: horizon
        );
        var model = pipeline.Fit(data);
        Directory.CreateDirectory(ModelDirectory);
        string modelPath = Path.Combine(ModelDirectory, $"{cacheKey}.zip");
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
        return model;
    }

    private static void DeleteModelFiles(string modelPath, string metaPath)
    {
        if (File.Exists(modelPath))
            File.Delete(modelPath);
        if (File.Exists(metaPath))
            File.Delete(metaPath);
    }

    private static ITransformer? LoadModel(MLContext mlContext, string modelPath)
    {
        using var fileStream = new FileStream(
            modelPath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read
        );
        return mlContext.Model.Load(fileStream, out var _);
    }

    private static DateTime LoadTrainedOn(string metaPath, DateTime fallback)
    {
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
                return metaDate;
        }
        return fallback;
    }
}
