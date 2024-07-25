using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class FeedbacksExtensions
{
    public static Feedback ToDto(this FeedbackDbModel model)
    {
        return new Feedback
        {
            Id = model.Id,
            Date = model.Date,
            Rating = model.Rating,
            Comment = model.Comment,
            Users = model.UsersId,
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
        if (updateDto.Rating != null)
        {
            feedback.Rating = updateDto.Rating;
        }
        if (updateDto.Users != null)
        {
            feedback.Users = updateDto.Users.Value;
        }

        return feedback;
    }
}
