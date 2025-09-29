using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class PromotionService
        : BaseService<
            Promotion,
            PromotionDto,
            CreatePromotionDto,
            UpdatePromotionDto,
            PatchPromotionDto
        >,
            IPromotionService
    {
        public PromotionService(IPromotionRepository promotionRepository, IMapper mapper)
            : base(promotionRepository, mapper) { }
    }
}
