using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class SalesOrderService
        : BaseService<
            SalesOrder,
            SalesOrderDto,
            CreateSalesOrderDto,
            UpdateSalesOrderDto,
            PatchSalesOrderDto
        >,
            ISalesOrderService
    {
        private readonly IQuotationRepository _quotationRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public SalesOrderService(
            ISalesOrderRepository salesOrderRepository,
            IQuotationRepository quotationRepository,
            IVehicleRepository vehicleRepository,
            IMapper mapper
        )
            : base(salesOrderRepository, mapper)
        {
            _quotationRepository = quotationRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<SalesOrderDto> CreateAsync(CreateSalesOrderDto dto, Guid userId)
        {
            // Get Quotation
            var quotation =
                await _quotationRepository.GetByIdAsync(dto.QuotationId)
                ?? throw new KeyNotFoundException(
                    $"Quotation with ID {dto.QuotationId} does not exist."
                );

            // Find available vehicle for sale
            var vehicles = await _vehicleRepository.FindAsync(v =>
                v.VariantId == quotation.VariantId
                && v.Color == quotation.Color
                && v.Status == VehicleStatus.Available
                && v.Type == VehicleType.Sale
            );
            var vehicle =
                vehicles.FirstOrDefault()
                ?? throw new InvalidOperationException(
                    "No available vehicle for sale matching the quotation's variant and color."
                );

            // Reserve the vehicle
            vehicle.Status = VehicleStatus.Reserved;
            _vehicleRepository.Update(vehicle);
            await _vehicleRepository.SaveChangesAsync();

            // Create SalesOrder
            var salesOrder = new SalesOrder
            {
                QuotationId = quotation.Id,
                DealerId = quotation.DealerId,
                UserId = userId,
                CustomerId = quotation.CustomerId,
                VehicleId = vehicle.Id,
                Date = DateTime.UtcNow,
                Status = SalesOrderStatus.Pending,
            };

            await _repository.AddAsync(salesOrder);
            await _repository.SaveChangesAsync();

            return _mapper.Map<SalesOrderDto>(salesOrder);
        }
    }
}
