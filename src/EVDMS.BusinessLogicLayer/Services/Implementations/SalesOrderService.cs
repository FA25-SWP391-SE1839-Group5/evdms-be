using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.Common.Utils;
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
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAuditLogService _auditLogService;
        private readonly IUserRepository _userRepository;

        public SalesOrderService(
            ISalesOrderRepository salesOrderRepository,
            IQuotationRepository quotationRepository,
            IVehicleRepository vehicleRepository,
            IPaymentRepository paymentRepository,
            IUserRepository userRepository,
            IMapper mapper,
            IAuditLogService auditLogService
        )
            : base(salesOrderRepository, mapper)
        {
            _quotationRepository = quotationRepository;
            _vehicleRepository = vehicleRepository;
            _paymentRepository = paymentRepository;
            _userRepository = userRepository;
            _auditLogService = auditLogService;
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

            // Log CreateSalesOrder event
            await _auditLogService.CreateAsync(
                new CreateAuditLogDto
                {
                    UserId = userId,
                    Action = AuditLogAction.CreateSalesOrder,
                    Description = $"Sales order {salesOrder.Id} created by user {userId}.",
                }
            );

            return _mapper.Map<SalesOrderDto>(salesOrder);
        }

        public async Task DeliverAsync(Guid salesOrderId)
        {
            var salesOrder =
                await _repository.GetByIdAsync(salesOrderId)
                ?? throw new KeyNotFoundException(
                    $"SalesOrder with ID {salesOrderId} does not exist."
                );

            if (salesOrder.Status == SalesOrderStatus.Delivered)
                throw new InvalidOperationException("SalesOrder is already delivered.");

            var vehicle =
                await _vehicleRepository.GetByIdAsync(salesOrder.VehicleId)
                ?? throw new KeyNotFoundException(
                    $"Vehicle with ID {salesOrder.VehicleId} does not exist."
                );

            salesOrder.Status = SalesOrderStatus.Delivered;
            _repository.Update(salesOrder);

            vehicle.Status = VehicleStatus.Sold;
            _vehicleRepository.Update(vehicle);

            await _repository.SaveChangesAsync();
            await _vehicleRepository.SaveChangesAsync();

            // Log DeliverSalesOrder event
            await _auditLogService.CreateAsync(
                new CreateAuditLogDto
                {
                    UserId = salesOrder.UserId,
                    Action = AuditLogAction.DeliverSalesOrder,
                    Description =
                        $"Sales order {salesOrder.Id} delivered by user {salesOrder.UserId}.",
                }
            );
        }

        public async Task<SalesOrderSummaryDto> GetSummaryAsync(Guid salesOrderId)
        {
            var salesOrder =
                await _repository.GetByIdAsync(salesOrderId)
                ?? throw new KeyNotFoundException("SalesOrder not found");

            var quotation =
                await _quotationRepository.GetByIdAsync(salesOrder.QuotationId)
                ?? throw new KeyNotFoundException("Quotation not found");

            var payments = await _paymentRepository.FindAsync(p => p.SalesOrderId == salesOrderId);
            decimal paidAmount = payments.Sum(p => p.Amount);
            decimal totalAmount = quotation.TotalAmount;
            decimal outstandingBalance = totalAmount - paidAmount;
            bool isFullyPaid = outstandingBalance <= 0;

            return new SalesOrderSummaryDto
            {
                SalesOrderId = salesOrderId,
                TotalAmount = totalAmount,
                PaidAmount = paidAmount,
                OutstandingBalance = outstandingBalance,
                IsFullyPaid = isFullyPaid,
            };
        }

        public async Task<
            PaginatedResult<DealerStaffSalesReportDto>
        > GetDealerStaffSalesReportAsync(
            int page = 1,
            int pageSize = 10,
            string? sortBy = null,
            string? sortOrder = null,
            DateTime? startDate = null,
            DateTime? endDate = null
        )
        {
            var orders = await _repository.FindAsync(o =>
                (o.Status == SalesOrderStatus.Confirmed || o.Status == SalesOrderStatus.Delivered)
                && (!startDate.HasValue || o.Date >= startDate.Value)
                && (!endDate.HasValue || o.Date <= endDate.Value)
            );

            var grouped = orders.GroupBy(o => o.UserId).ToList();
            var userIds = grouped.Select(g => g.Key).ToList();

            var users = await _userRepository.FindAsync(u => userIds.Contains(u.Id));
            var staffNames = users.ToDictionary(u => u.Id, u => u.FullName);

            var result = grouped
                .Select(g =>
                {
                    var firstOrder = g.First();
                    var dto = _mapper.Map<DealerStaffSalesReportDto>(firstOrder);
                    dto.StaffId = g.Key;
                    dto.StaffName = staffNames.TryGetValue(g.Key, out var name)
                        ? name
                        : string.Empty;
                    dto.TotalOrders = g.Count();
                    dto.TotalAmount = g.Sum(o =>
                    {
                        var quotation = _quotationRepository.GetByIdAsync(o.QuotationId).Result;
                        return quotation?.TotalAmount ?? 0;
                    });
                    return dto;
                })
                .ToList();

            sortBy = sortBy?.ToLowerInvariant();
            sortOrder = sortOrder?.ToLowerInvariant() ?? "asc";
            result = sortBy switch
            {
                "totalorders" => sortOrder == "desc"
                    ? [.. result.OrderByDescending(x => x.TotalOrders)]
                    : [.. result.OrderBy(x => x.TotalOrders)],
                "totalamount" => sortOrder == "desc"
                    ? [.. result.OrderByDescending(x => x.TotalAmount)]
                    : [.. result.OrderBy(x => x.TotalAmount)],
                "staffname" => sortOrder == "desc"
                    ? [.. result.OrderByDescending(x => x.StaffName)]
                    : [.. result.OrderBy(x => x.StaffName)],
                _ => [.. result.OrderBy(x => x.StaffName)],
            };

            var totalResults = result.Count;
            var paged = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedResult<DealerStaffSalesReportDto>
            {
                Items = paged,
                TotalResults = totalResults,
                Page = page,
                PageSize = pageSize,
            };
        }

        public async Task<CsvExportResult> ExportDealerStaffSalesReportToCsvAsync(
            DateTime? startDate = null,
            DateTime? endDate = null
        )
        {
            var result = await GetDealerStaffSalesReportAsync(
                1,
                int.MaxValue,
                null,
                null,
                startDate,
                endDate
            );
            var csv =
                "StaffId,StaffName,TotalOrders,TotalAmount\n"
                + string.Join(
                    "\n",
                    result.Items.Select(x =>
                        $"{x.StaffId},{CsvUtils.EscapeCsv(x.StaffName)},{x.TotalOrders},{x.TotalAmount}"
                    )
                );
            var fileName = CsvUtils.BuildCsvFileName(
                "evdms_dealer_staff_sales_report",
                startDate,
                endDate
            );
            return new CsvExportResult { FileName = fileName, CsvContent = csv };
        }
    }
}
