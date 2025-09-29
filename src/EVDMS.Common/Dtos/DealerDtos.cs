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
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Region { get; set; }

        [Required]
        public required string Address { get; set; }
    }

    public class UpdateDealerDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Region { get; set; }

        [Required]
        public required string Address { get; set; }
    }

    public class PatchDealerDto
    {
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Address { get; set; }
    }
}
