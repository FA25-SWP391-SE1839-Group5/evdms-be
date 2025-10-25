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
                // Saigon Auto Hub (DealerId:30000000-0000-0000-0000-000000000002)
                new Feedback
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    Content = "Very professional and quick delivery.",
                    Status = FeedbackStatus.New,
                },
                new Feedback
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000005"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    Content = "Helpful staff and good after-sales support.",
                    Status = FeedbackStatus.Reviewed,
                },
                // Hanoi EV Center (DealerId:30000000-0000-0000-0000-000000000003)
                new Feedback
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000006"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    Content = "Smooth transaction and friendly staff.",
                    Status = FeedbackStatus.New,
                },
                new Feedback
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000007"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    Content = "Showroom was clean and well organized.",
                    Status = FeedbackStatus.Reviewed,
                },
                // Da Nang Green Motors (DealerId:30000000-0000-0000-0000-000000000004)
                new Feedback
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000008"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    Content = "Fast service and knowledgeable staff.",
                    Status = FeedbackStatus.New,
                },
                new Feedback
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000009"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    Content = "Good experience overall, will recommend.",
                    Status = FeedbackStatus.Reviewed,
                },
            ];
    }
}
