using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class DealerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class CreateDealerDto
    {
        public required string Name { get; set; }
        public required string Region { get; set; }
        public required string Address { get; set; }
    }

    public class UpdateDealerDto
    {
        public required string Name { get; set; }
        public required string Region { get; set; }
        public required string Address { get; set; }
    }

    public class PatchDealerDto
    {
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Address { get; set; }
    }
}
