using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class FeedbacksExtensions
{
    public static Feedback ToDto(this FeedbackDbModel model)
    {
        return new Feedback
        {
            Id = model.Id,
            Date = model.Date,
            User = model.UserId,
            Rating = model.Rating,
            Comment = model.Comment,
        };
    }

    public static FeedbackDbModel ToModel(
        this FeedbackUpdateInput updateDto,
        FeedbackWhereUniqueInput uniqueId
    )
    {
        var feedback = new FeedbackDbModel { Id = uniqueId.Id, Comment = updateDto.Comment };

        // map required fields
        if (updateDto.Date != null)
        {
            feedback.Date = updateDto.Date.Value;
        }
        if (updateDto.User != null)
        {
            feedback.User = updateDto.User.Value;
        }
        if (updateDto.Rating != null)
        {
            feedback.Rating = updateDto.Rating;
        }

        return feedback;
    }
}
