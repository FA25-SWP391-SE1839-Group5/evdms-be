using System.Threading.Tasks;
using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IDealerOrderService
        : IBaseService<
            DealerOrderDto,
            CreateDealerOrderDto,
            UpdateDealerOrderDto,
            PatchDealerOrderDto
        >
    {
        Task<DealerOrderDto> CreateAsync(Guid dealerId, CreateDealerOrderDto dto);
        Task DeliverOrderAsync(Guid orderId);
    }
}
