using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime LastLoginAt { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateUserDto
    {
        public Guid? DealerId { get; set; }

        [Required]
        public required string FullName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public UserRole Role { get; set; }
    }

    public class UpdateUserDto
    {
        public Guid? DealerId { get; set; }

        [Required]
        public required string FullName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }
    }

    public class PatchUserDto
    {
        public Guid? DealerId { get; set; }
        public string? FullName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public UserRole? Role { get; set; }
    }
}
