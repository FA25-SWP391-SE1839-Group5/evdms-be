using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class OemInventoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateOemInventoryDto
    {
        [Required]
        public required string Name { get; set; } = string.Empty;

        [Required]
        public required int Quantity { get; set; }
    }

    public class UpdateOemInventoryDto
    {
        [Required]
        public required string Name { get; set; } = string.Empty;

        [Required]
        public required int Quantity { get; set; }
    }

    public class PatchOemInventoryDto
    {
        public string? Name { get; set; }
        public int? Quantity { get; set; }
    }
}
