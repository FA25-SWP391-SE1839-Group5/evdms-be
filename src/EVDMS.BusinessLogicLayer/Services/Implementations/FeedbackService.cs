using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class FeedbackService
        : BaseService<
            Feedback,
            FeedbackDto,
            CreateFeedbackDto,
            UpdateFeedbackDto,
            PatchFeedbackDto
        >,
            IFeedbackService
    {
        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
            : base(feedbackRepository, mapper) { }
    }
}
