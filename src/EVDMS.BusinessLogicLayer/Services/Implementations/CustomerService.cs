using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class CustomerService
        : BaseService<
            Customer,
            CustomerDto,
            CreateCustomerDto,
            UpdateCustomerDto,
            PatchCustomerDto
        >,
            ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
            : base(customerRepository, mapper) { }
    }
}
