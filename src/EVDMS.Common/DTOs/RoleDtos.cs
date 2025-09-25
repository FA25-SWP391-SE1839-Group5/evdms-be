using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.DTOs
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        [Required]
        public string RoleName { get; set; } = string.Empty;
    }

    public class CreateRoleDto
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }

    public class UpdateRoleDto
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }

    public class PatchRoleDto
    {
        public string? RoleName { get; set; }
    }
}
