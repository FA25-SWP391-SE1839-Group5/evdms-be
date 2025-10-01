using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IFeedbackService
        : IBaseService<FeedbackDto, CreateFeedbackDto, UpdateFeedbackDto, PatchFeedbackDto> { }
}
