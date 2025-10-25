using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class DealerOrderService
        : BaseService<
            DealerOrder,
            DealerOrderDto,
            CreateDealerOrderDto,
            UpdateDealerOrderDto,
            PatchDealerOrderDto
        >,
            IDealerOrderService
    {
        private readonly IDealerOrderRepository _dealerOrderRepository;
        private readonly IDealerContractRepository _dealerContractRepository;
        private readonly IVehicleVariantRepository _vehicleVariantRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IAuditLogService _auditLogService;

        private static DateTime Now => DateTime.UtcNow;

        public DealerOrderService(
            IDealerOrderRepository dealerOrderRepository,
            IDealerContractRepository dealerContractRepository,
            IVehicleVariantRepository vehicleVariantRepository,
            IVehicleRepository vehicleRepository,
            IVehicleModelRepository vehicleModelRepository,
            IMapper mapper,
            IAuditLogService auditLogService
        )
            : base(dealerOrderRepository, mapper)
        {
            _dealerOrderRepository = dealerOrderRepository;
            _dealerContractRepository = dealerContractRepository;
            _vehicleVariantRepository = vehicleVariantRepository;
            _vehicleRepository = vehicleRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _auditLogService = auditLogService;
        }

        public async Task<DealerOrderDto> CreateAsync(Guid dealerId, CreateDealerOrderDto dto)
        {
            _ =
                (
                    await _dealerContractRepository.FindAsync(c =>
                        c.DealerId == dealerId && c.StartDate <= Now && c.EndDate >= Now
                    )
                ).FirstOrDefault()
                ?? throw new KeyNotFoundException(
                    $"No active contracts found for dealer with ID: {dealerId}."
                );

            _ =
                await _vehicleVariantRepository.GetByIdAsync(dto.VariantId)
                ?? throw new KeyNotFoundException(
                    $"VehicleVariant with id {dto.VariantId} does not exist."
                );

            var entity = _mapper.Map<DealerOrder>(dto);
            entity.DealerId = dealerId;
            entity.Status = DealerOrderStatus.Pending;
            await _dealerOrderRepository.AddAsync(entity);
            await _dealerOrderRepository.SaveChangesAsync();

            // Log CreateDealerOrder event
            await _auditLogService.CreateAsync(
                new CreateAuditLogDto
                {
                    UserId = dealerId,
                    Action = AuditLogAction.CreateDealerOrder,
                    Description = $"Dealer order {entity.Id} created for dealer {dealerId}.",
                }
            );

            return _mapper.Map<DealerOrderDto>(entity);
        }

        public async Task DeliverOrderAsync(Guid orderId, Guid userId)
        {
            var order =
                await _dealerOrderRepository.GetByIdAsync(orderId)
                ?? throw new KeyNotFoundException($"Order {orderId} not found.");

            if (order.Status != DealerOrderStatus.Confirmed)
                throw new InvalidOperationException("Order must be confirmed before delivery.");

            var variant =
                await _vehicleVariantRepository.GetByIdAsync(order.VariantId)
                ?? throw new KeyNotFoundException($"Variant {order.VariantId} not found.");

            // Ensure VehicleModel is loaded
            if (variant.VehicleModel == null)
            {
                var vehicleModel =
                    await _vehicleModelRepository.GetByIdAsync(variant.ModelId)
                    ?? throw new KeyNotFoundException(
                        $"VehicleModel for variant {variant.Id} not found."
                    );
                variant.VehicleModel = vehicleModel;
            }
            if (string.IsNullOrWhiteSpace(variant.VehicleModel.Name))
                throw new InvalidOperationException(
                    $"VehicleModel name for variant {variant.Id} is missing."
                );

            // Query all vehicles for this variant
            var existingVehicles = await _vehicleRepository.FindAsync(v =>
                v.VariantId == variant.Id
            );
            int maxSerial = 0;
            foreach (var v in existingVehicles)
            {
                if (v.Vin.Length >= 6 && int.TryParse(v.Vin[^6..], out int serial))
                {
                    if (serial > maxSerial)
                        maxSerial = serial;
                }
            }
            int startSerial = maxSerial + 1;

            var batchVins = new HashSet<string>(); // Track VINs generated in this batch
            string plantCode = "A"; // Default plant code

            for (int i = 0; i < order.Quantity; i++)
            {
                int serial = startSerial + i;
                string vin;
                bool vinExists;
                do
                {
                    vin = VinGenerator.GenerateVin(
                        variant.Name,
                        DateTime.UtcNow.Year,
                        serial,
                        plantCode
                    );
                    vinExists =
                        batchVins.Contains(vin)
                        || (await _vehicleRepository.FindAsync(v => v.Vin == vin)).Any();
                    if (vinExists)
                        serial++;
                } while (vinExists);

                batchVins.Add(vin); // Add to batch set

                var vehicle = new Vehicle
                {
                    VariantId = variant.Id,
                    DealerId = order.DealerId,
                    Vin = vin,
                    Color = order.Color,
                    Type = VehicleType.Display,
                    Status = VehicleStatus.Available,
                };
                await _vehicleRepository.AddAsync(vehicle);
            }

            order.Status = DealerOrderStatus.Delivered;
            _dealerOrderRepository.Update(order);
            await _dealerOrderRepository.SaveChangesAsync();

            // Log DeliverSalesOrder event
            await _auditLogService.CreateAsync(
                new CreateAuditLogDto
                {
                    UserId = userId,
                    Action = AuditLogAction.DeliverSalesOrder,
                    Description = $"Dealer order {order.Id} delivered for dealer {order.DealerId}.",
                }
            );
        }

        public async Task<PaginatedResult<VariantOrderRateDto>> GetDeliveredOrdersByVariantAsync(
            int page = 1,
            int pageSize = 10,
            string? sortBy = null,
            string? sortOrder = null,
            DateTime? startDate = null,
            DateTime? endDate = null
        )
        {
            var deliveredOrders = await _dealerOrderRepository.FindAsync(o =>
                o.Status == DealerOrderStatus.Delivered
                && (!startDate.HasValue || o.UpdatedAt >= startDate.Value)
                && (!endDate.HasValue || o.UpdatedAt <= endDate.Value)
            );
            var totalQuantity = deliveredOrders.Sum(o => o.Quantity);
            if (totalQuantity == 0)
                return new PaginatedResult<VariantOrderRateDto>
                {
                    Items = [],
                    TotalResults = 0,
                    Page = page,
                    PageSize = pageSize,
                };

            // Group by VariantId
            var grouped = deliveredOrders.GroupBy(o => o.VariantId).ToList();

            // Load variant names
            var variantIds = grouped.Select(g => g.Key).ToList();
            var variants = (
                await _vehicleVariantRepository.FindAsync(v => variantIds.Contains(v.Id))
            ).ToDictionary(v => v.Id, v => v.Name);

            var result = grouped
                .Select(g =>
                {
                    var firstOrder = g.First();
                    var dto = _mapper.Map<VariantOrderRateDto>(firstOrder);
                    dto.OrderCount = g.Sum(o => o.Quantity);
                    dto.Percentage = Math.Round((double)dto.OrderCount / totalQuantity * 100, 2);
                    dto.VariantName = variants.TryGetValue(g.Key, out var name)
                        ? name
                        : string.Empty;
                    return dto;
                })
                .ToList();

            // Sorting
            sortBy = sortBy?.ToLowerInvariant();
            sortOrder = sortOrder?.ToLowerInvariant() ?? "asc";
            result = sortBy switch
            {
                "ordercount" => sortOrder == "desc"
                    ? [.. result.OrderByDescending(x => x.OrderCount)]
                    : [.. result.OrderBy(x => x.OrderCount)],
                "percentage" => sortOrder == "desc"
                    ? [.. result.OrderByDescending(x => x.Percentage)]
                    : [.. result.OrderBy(x => x.Percentage)],
                "variantname" => sortOrder == "desc"
                    ? [.. result.OrderByDescending(x => x.VariantName)]
                    : [.. result.OrderBy(x => x.VariantName)],
                _ => [.. result.OrderBy(x => x.VariantName)],
            };

            // Pagination
            var totalResults = result.Count;
            var paged = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedResult<VariantOrderRateDto>
            {
                Items = paged,
                TotalResults = totalResults,
                Page = page,
                PageSize = pageSize,
            };
        }

        public async Task<CsvExportResult> ExportDeliveredOrdersByVariantToCsvAsync(
            DateTime? startDate = null,
            DateTime? endDate = null
        )
        {
            var result = await GetDeliveredOrdersByVariantAsync(
                1,
                int.MaxValue,
                null,
                null,
                startDate,
                endDate
            );
            var csv =
                "VariantId,VariantName,OrderCount,Percentage\n"
                + string.Join(
                    "\n",
                    result.Items.Select(x =>
                        $"{x.VariantId},{CsvUtils.EscapeCsv(x.VariantName)},{x.OrderCount},{x.Percentage}"
                    )
                );
            var fileName = CsvUtils.BuildCsvFileName(
                "evdms_variant_order_rates",
                startDate,
                endDate
            );
            return new CsvExportResult { FileName = fileName, CsvContent = csv };
        }
    }
}
