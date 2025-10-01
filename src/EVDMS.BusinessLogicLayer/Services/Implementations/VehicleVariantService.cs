using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Helpers;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class VehicleVariantService
        : BaseService<
            VehicleVariant,
            VehicleVariantDto,
            CreateVehicleVariantDto,
            UpdateVehicleVariantDto,
            PatchVehicleVariantDto
        >,
            IVehicleVariantService
    {
        public VehicleVariantService(
            IVehicleVariantRepository vehicleVariantRepository,
            IMapper mapper
        )
            : base(vehicleVariantRepository, mapper) { }

        public override async Task<VehicleVariantDto> CreateAsync(CreateVehicleVariantDto dto)
        {
            if (
                dto.Features != null
                && !VehicleFeaturesValidator.IsValid(dto.Features, out var error)
            )
                throw new ValidationException(error);
            return await base.CreateAsync(dto);
        }

        public override async Task<bool> UpdateAsync(Guid id, UpdateVehicleVariantDto dto)
        {
            if (
                dto.Features != null
                && !VehicleFeaturesValidator.IsValid(dto.Features, out var error)
            )
                throw new ValidationException(error);
            return await base.UpdateAsync(id, dto);
        }
    }
}
