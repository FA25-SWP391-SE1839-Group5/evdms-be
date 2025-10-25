using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class VehicleService
        : BaseService<Vehicle, VehicleDto, CreateVehicleDto, UpdateVehicleDto, PatchVehicleDto>,
            IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
            : base(vehicleRepository, mapper)
        {
            _vehicleRepository = vehicleRepository;
        }

        public override async Task<VehicleDto> CreateAsync(CreateVehicleDto dto)
        {
            var exists = (await _vehicleRepository.FindAsync(x => x.Vin == dto.Vin)).Any();
            if (exists)
            {
                throw new InvalidOperationException("A vehicle with this VIN already exists.");
            }
            var entity = _mapper.Map<Vehicle>(dto);
            await _vehicleRepository.AddAsync(entity);
            await _vehicleRepository.SaveChangesAsync();
            return _mapper.Map<VehicleDto>(entity);
        }
    }
}
