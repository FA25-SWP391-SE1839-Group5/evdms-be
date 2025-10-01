using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Dtos
{
    public class FeedbackDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DealerId { get; set; }
        public string Content { get; set; } = string.Empty;
        public FeedbackStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateFeedbackDto
    {
        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        [MinLength(1)]
        public required string Content { get; set; }

        [Required]
        public required FeedbackStatus Status { get; set; }
    }

    public class UpdateFeedbackDto
    {
        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        [MinLength(1)]
        public required string Content { get; set; }

        [Required]
        public required FeedbackStatus Status { get; set; }
    }

    public class PatchFeedbackDto
    {
        public Guid? CustomerId { get; set; }

        public Guid? DealerId { get; set; }

        public string? Content { get; set; }

        public FeedbackStatus? Status { get; set; }
    }
}
