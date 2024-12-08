using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class BookingsExtensions
{
    public static Booking ToDto(this BookingDbModel model)
    {
        return new Booking
        {
            Id = model.Id,
            Uid = model.Uid,
            User = model.UserId,
            EventType = model.EventTypeId,
            Title = model.Title,
            Description = model.Description,
            CustomInputs = model.CustomInputs,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            Location = model.Location,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Status = model.Status,
            Paid = model.Paid,
            CancellationReason = model.CancellationReason,
            RejectionReason = model.RejectionReason,
            DynamicEventSlugRef = model.DynamicEventSlugRef,
            DynamicGroupSlugRef = model.DynamicGroupSlugRef,
            Rescheduled = model.Rescheduled,
            FromReschedule = model.FromReschedule,
            RecurringEventId = model.RecurringEventId,
            SmsReminderNumber = model.SmsReminderNumber,
            DestinationCalendar = model.DestinationCalendar?.ToDto(),
            References = model.References?.Select(x => x.Id).ToList(),
            Attendees = model.Attendees?.Select(x => x.Id).ToList(),
            DailyRef = model.DailyRef?.ToDto(),
            Payment = model.Payment?.Select(x => x.Id).ToList(),
            WorkflowReminders = model.WorkflowReminders?.Select(x => x.Id).ToList(),
        };
    }

    public static BookingDbModel ToModel(
        this BookingUpdateInput updateDto,
        BookingWhereUniqueInput uniqueId
    )
    {
        var booking = new BookingDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            CustomInputs = updateDto.CustomInputs,
            Location = updateDto.Location,
            UpdatedAt = updateDto.UpdatedAt,
            CancellationReason = updateDto.CancellationReason,
            RejectionReason = updateDto.RejectionReason,
            DynamicEventSlugRef = updateDto.DynamicEventSlugRef,
            DynamicGroupSlugRef = updateDto.DynamicGroupSlugRef,
            Rescheduled = updateDto.Rescheduled,
            FromReschedule = updateDto.FromReschedule,
            RecurringEventId = updateDto.RecurringEventId,
            SmsReminderNumber = updateDto.SmsReminderNumber
        };

        // map required fields
        if (updateDto.Uid != null)
        {
            booking.Uid = updateDto.Uid;
        }
        if (updateDto.Title != null)
        {
            booking.Title = updateDto.Title;
        }
        if (updateDto.StartTime != null)
        {
            booking.StartTime = updateDto.StartTime.Value;
        }
        if (updateDto.EndTime != null)
        {
            booking.EndTime = updateDto.EndTime.Value;
        }
        if (updateDto.CreatedAt != null)
        {
            booking.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Status != null)
        {
            booking.Status = updateDto.Status.Value;
        }
        if (updateDto.Paid != null)
        {
            booking.Paid = updateDto.Paid.Value;
        }

        return booking;
    }
}
