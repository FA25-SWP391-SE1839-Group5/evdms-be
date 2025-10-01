using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Dtos
{
    public class TestDriveDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DealerId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime ScheduledAt { get; set; }
        public TestDriveStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateTestDriveDto
    {
        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required Guid VehicleId { get; set; }

        [Required]
        public required DateTime ScheduledAt { get; set; }

        [Required]
        public required TestDriveStatus Status { get; set; }
    }

    public class UpdateTestDriveDto
    {
        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required Guid VehicleId { get; set; }

        [Required]
        public required DateTime ScheduledAt { get; set; }

        [Required]
        public required TestDriveStatus Status { get; set; }
    }

    public class PatchTestDriveDto
    {
        public Guid? CustomerId { get; set; }

        public Guid? DealerId { get; set; }

        public Guid? VehicleId { get; set; }

        public DateTime? ScheduledAt { get; set; }

        public TestDriveStatus? Status { get; set; }
    }
}
