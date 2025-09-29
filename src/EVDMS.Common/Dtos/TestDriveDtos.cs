using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class TestDriveDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DealerId { get; set; }
        public DateTime ScheduledAt { get; set; }
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
        public required DateTime ScheduledAt { get; set; }
    }

    public class UpdateTestDriveDto
    {
        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required DateTime ScheduledAt { get; set; }
    }

    public class PatchTestDriveDto
    {
        public Guid? CustomerId { get; set; }
        public Guid? DealerId { get; set; }
        public DateTime? ScheduledAt { get; set; }
    }
}
