using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IPromotionService
        : IBaseService<PromotionDto, CreatePromotionDto, UpdatePromotionDto, PatchPromotionDto> { }
}
