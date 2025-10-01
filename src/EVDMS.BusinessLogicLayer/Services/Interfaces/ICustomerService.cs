using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface ICustomerService
        : IBaseService<CustomerDto, CreateCustomerDto, UpdateCustomerDto, PatchCustomerDto> { }
}
