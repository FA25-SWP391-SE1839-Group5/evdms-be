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
        public OemInventoryService(IOemInventoryRepository oemInventoryRepository, IMapper mapper)
            : base(oemInventoryRepository, mapper) { }
    }
}
