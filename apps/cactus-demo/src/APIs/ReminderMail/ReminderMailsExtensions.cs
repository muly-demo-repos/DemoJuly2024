using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class ReminderMailsExtensions
{
    public static ReminderMail ToDto(this ReminderMailDbModel model)
    {
        return new ReminderMail
        {
            Id = model.Id,
            ReferenceId = model.ReferenceId,
            ReminderType = model.ReminderType,
            ElapsedMinutes = model.ElapsedMinutes,
            CreatedAt = model.CreatedAt,
        };
    }

    public static ReminderMailDbModel ToModel(
        this ReminderMailUpdateInput updateDto,
        ReminderMailWhereUniqueInput uniqueId
    )
    {
        var reminderMail = new ReminderMailDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.ReferenceId != null)
        {
            reminderMail.ReferenceId = updateDto.ReferenceId.Value;
        }
        if (updateDto.ReminderType != null)
        {
            reminderMail.ReminderType = updateDto.ReminderType.Value;
        }
        if (updateDto.ElapsedMinutes != null)
        {
            reminderMail.ElapsedMinutes = updateDto.ElapsedMinutes.Value;
        }
        if (updateDto.CreatedAt != null)
        {
            reminderMail.CreatedAt = updateDto.CreatedAt.Value;
        }

        return reminderMail;
    }
}
