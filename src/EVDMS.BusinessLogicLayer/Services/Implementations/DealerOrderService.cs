using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
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
        private readonly IVehicleVariantRepository _vehicleVariantRepository;

        public DealerOrderService(
            IDealerOrderRepository dealerOrderRepository,
            IVehicleVariantRepository vehicleVariantRepository,
            IMapper mapper
        )
            : base(dealerOrderRepository, mapper)
        {
            _dealerOrderRepository = dealerOrderRepository;
            _vehicleVariantRepository = vehicleVariantRepository;
        }

        public async Task<DealerOrderDto> CreateAsync(Guid dealerId, CreateDealerOrderDto dto)
        {
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
    }
}
