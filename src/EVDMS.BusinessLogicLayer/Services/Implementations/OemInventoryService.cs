using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class OemInventoryService
        : BaseService<
            OemInventory,
            OemInventoryDto,
            CreateOemInventoryDto,
            UpdateOemInventoryDto,
            PatchOemInventoryDto
        >,
            IOemInventoryService
    {
        private readonly IOemInventoryRepository _oemInventoryRepository;

        public OemInventoryService(IOemInventoryRepository oemInventoryRepository, IMapper mapper)
            : base(oemInventoryRepository, mapper)
        {
            _oemInventoryRepository = oemInventoryRepository;
        }

        public override async Task<OemInventoryDto> CreateAsync(CreateOemInventoryDto dto)
        {
            var exists = (
                await _oemInventoryRepository.FindAsync(x => x.VariantId == dto.VariantId)
            ).Any();
            if (exists)
            {
                throw new InvalidOperationException(
                    "An OemInventory with this variantId already exists."
                );
            }
            var entity = _mapper.Map<OemInventory>(dto);
            await _oemInventoryRepository.AddAsync(entity);
            await _oemInventoryRepository.SaveChangesAsync();
            return _mapper.Map<OemInventoryDto>(entity);
        }
    }
}
