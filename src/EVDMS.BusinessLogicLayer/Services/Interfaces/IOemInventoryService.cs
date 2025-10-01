using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IOemInventoryService
        : IBaseService<
            OemInventoryDto,
            CreateOemInventoryDto,
            UpdateOemInventoryDto,
            PatchOemInventoryDto
        > { }
}
