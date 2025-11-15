using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IPromotionService
        : IBaseService<PromotionDto, CreatePromotionDto, UpdatePromotionDto, PatchPromotionDto>
    {
        Task<PromotionDto> CreateAsync(
            CreatePromotionDto dto,
            UserRole userRole,
            Guid? dealerId = null
        );
    }
}
