using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Implementations;
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

        private static DateTime Now => DateTime.UtcNow;

        public DealerOrderService(
            IDealerOrderRepository dealerOrderRepository,
            IDealerContractRepository dealerContractRepository,
            IVehicleVariantRepository vehicleVariantRepository,
            IVehicleRepository vehicleRepository,
            IVehicleModelRepository vehicleModelRepository,
            IMapper mapper
        )
            : base(dealerOrderRepository, mapper)
        {
            _dealerOrderRepository = dealerOrderRepository;
            _dealerContractRepository = dealerContractRepository;
            _vehicleVariantRepository = vehicleVariantRepository;
            _vehicleRepository = vehicleRepository;
            _vehicleModelRepository = vehicleModelRepository;
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
            return _mapper.Map<DealerOrderDto>(entity);
        }

        public async Task DeliverOrderAsync(Guid orderId)
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

                var createVehicleDto = new CreateVehicleDto
                {
                    VariantId = variant.Id,
                    DealerId = order.DealerId,
                    Vin = vin,
                    Color = order.Color,
                    Type = VehicleType.Display,
                    Status = VehicleStatus.Available,
                };
                var vehicle = _mapper.Map<Vehicle>(createVehicleDto);
                await _vehicleRepository.AddAsync(vehicle);
            }

            order.Status = DealerOrderStatus.Delivered;
            _dealerOrderRepository.Update(order);
            await _dealerOrderRepository.SaveChangesAsync();
        }
    }
}
