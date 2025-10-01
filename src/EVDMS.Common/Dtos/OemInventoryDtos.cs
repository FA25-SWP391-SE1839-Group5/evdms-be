using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class OemInventoryDto
    {
        public Guid Id { get; set; }
        public Guid VariantId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateOemInventoryDto
    {
        [Required]
        public required Guid VariantId { get; set; }

        [Required]
        public required int Quantity { get; set; }
    }

    public class UpdateOemInventoryDto
    {
        [Required]
        public required Guid VariantId { get; set; }

        [Required]
        public required int Quantity { get; set; }
    }

    public class PatchOemInventoryDto
    {
        public Guid? VariantId { get; set; }
        public int? Quantity { get; set; }
    }
}
