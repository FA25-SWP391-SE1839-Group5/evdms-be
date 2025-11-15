using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IQuotationService
        : IBaseService<QuotationDto, CreateQuotationDto, UpdateQuotationDto, PatchQuotationDto>
    {
        Task<QuotationDto> CreateAsync(CreateQuotationDto dto, Guid dealerId, Guid userId);
    }
}
