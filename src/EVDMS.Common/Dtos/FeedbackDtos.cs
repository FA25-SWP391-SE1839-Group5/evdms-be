using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class FeedbackDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid DealerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateFeedbackDto
    {
        [Required]
        public required string Content { get; set; } = string.Empty;

        [Required]
        public required Guid DealerId { get; set; }
    }

    public class UpdateFeedbackDto
    {
        [Required]
        public required string Content { get; set; } = string.Empty;

        [Required]
        public required Guid DealerId { get; set; }
    }

    public class PatchFeedbackDto
    {
        public string? Content { get; set; }
        public Guid? DealerId { get; set; }
    }
}
