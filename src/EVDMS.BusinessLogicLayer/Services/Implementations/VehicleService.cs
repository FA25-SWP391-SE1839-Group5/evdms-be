using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class VehicleService
        : BaseService<Vehicle, VehicleDto, CreateVehicleDto, UpdateVehicleDto, PatchVehicleDto>,
            IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleVariantRepository _vehicleVariantRepository;

        public VehicleService(
            IVehicleRepository vehicleRepository,
            IVehicleVariantRepository vehicleVariantRepository,
            IMapper mapper
        )
            : base(vehicleRepository, mapper)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleVariantRepository = vehicleVariantRepository;
        }

        public override async Task<VehicleDto> CreateAsync(CreateVehicleDto dto)
        {
            // Get variant name for VIN generation
            var variant =
                await _vehicleVariantRepository.GetByIdAsync(dto.VariantId)
                ?? throw new InvalidOperationException("Vehicle variant not found.");

            // Generate serial number (count +1 for this variant)
            int serialNumber =
                (await _vehicleRepository.FindAsync(x => x.VariantId == dto.VariantId)).Count() + 1;
            int year = DateTime.UtcNow.Year;
            string vin = VinGenerator.GenerateVin(variant.Name, year, serialNumber);

            // Ensure VIN is unique
            var exists = (await _vehicleRepository.FindAsync(x => x.Vin == vin)).Any();
            if (exists)
            {
                throw new InvalidOperationException("A vehicle with this VIN already exists.");
            }

            var entity = _mapper.Map<Vehicle>(dto);
            entity.Vin = vin;
            await _vehicleRepository.AddAsync(entity);
            await _vehicleRepository.SaveChangesAsync();
            return _mapper.Map<VehicleDto>(entity);
        }
    }
}
