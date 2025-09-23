using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.DTOs;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.UnitOfWork;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<CustomerDto>> GetAllAsync(int page, int pageSize)
        {
            var (customers, totalCount) = await _unitOfWork.Customers.GetPaginatedAsync(
                page,
                pageSize
            );
            return new PaginatedResult<CustomerDto>
            {
                Items = _mapper.Map<IEnumerable<CustomerDto>>(customers),
                TotalResults = totalCount,
                Page = page,
                PageSize = pageSize,
            };
        }

        public async Task<CustomerDto?> GetByIdAsync(Guid id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            return customer == null ? null : _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateCustomerDto dto)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
                return false;
            _mapper.Map(dto, customer);
            _unitOfWork.Customers.Update(customer);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> PatchAsync(Guid id, PatchCustomerDto dto)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
                return false;
            _mapper.Map(dto, customer);
            _unitOfWork.Customers.Update(customer);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
                return false;
            _unitOfWork.Customers.Remove(customer);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
