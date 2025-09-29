using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IQuotationService
        : IBaseService<QuotationDto, CreateQuotationDto, UpdateQuotationDto, PatchQuotationDto> { }
}
