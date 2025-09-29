using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class FeedbackSeed
    {
        public static List<Feedback> Feedbacks =>
            [
                new Feedback
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Content = "Great service and friendly staff!",
                    Status = FeedbackStatus.New,
                },
                new Feedback
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Content = "Quick response to my queries.",
                    Status = FeedbackStatus.Reviewed,
                },
                new Feedback
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000003"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Content = "Had some issues with paperwork, but resolved.",
                    Status = FeedbackStatus.Resolved,
                },
            ];
    }
}
