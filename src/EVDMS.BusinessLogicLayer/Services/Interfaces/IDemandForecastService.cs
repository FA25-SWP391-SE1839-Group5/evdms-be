using EVDMS.BusinessLogicLayer.Models;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IDemandForecastService
    {
        Task<VariantForecastResult?> ForecastVariantAsync(Guid variantId, int horizon = 14);
    }
}
