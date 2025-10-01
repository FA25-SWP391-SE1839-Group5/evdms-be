using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateCustomerDto
    {
        [Required]
        [MinLength(1)]
        public required string FullName { get; set; }

        [Required]
        [Phone]
        public required string Phone { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(1)]
        public required string Address { get; set; }
    }

    public class UpdateCustomerDto
    {
        [Required]
        [MinLength(1)]
        public required string FullName { get; set; }

        [Required]
        [Phone]
        public required string Phone { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(1)]
        public required string Address { get; set; }
    }

    public class PatchCustomerDto
    {
        public string? FullName { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
