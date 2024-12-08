using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class WorkflowRemindersExtensions
{
    public static WorkflowReminder ToDto(this WorkflowReminderDbModel model)
    {
        return new WorkflowReminder
        {
            Id = model.Id,
            Booking = model.BookingId,
            Method = model.Method,
            ScheduledDate = model.ScheduledDate,
            ReferenceId = model.ReferenceId,
            Scheduled = model.Scheduled,
            WorkflowStep = model.WorkflowStepId,
        };
    }

    public static WorkflowReminderDbModel ToModel(
        this WorkflowReminderUpdateInput updateDto,
        WorkflowReminderWhereUniqueInput uniqueId
    )
    {
        var workflowReminder = new WorkflowReminderDbModel
        {
            Id = uniqueId.Id,
            ReferenceId = updateDto.ReferenceId
        };

        // map required fields
        if (updateDto.Method != null)
        {
            workflowReminder.Method = updateDto.Method.Value;
        }
        if (updateDto.ScheduledDate != null)
        {
            workflowReminder.ScheduledDate = updateDto.ScheduledDate.Value;
        }
        if (updateDto.Scheduled != null)
        {
            workflowReminder.Scheduled = updateDto.Scheduled.Value;
        }
        if (updateDto.WorkflowStep != null)
        {
            workflowReminder.WorkflowStep = updateDto.WorkflowStep.Value;
        }

        return workflowReminder;
    }
}
