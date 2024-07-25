using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class BookingsExtensions
{
    public static Booking ToDto(this BookingDbModel model)
    {
        return new Booking
        {
            Id = model.Id,
            Uid = model.Uid,
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
            EventType = model.EventTypeId,
            Users = model.UsersId,
            Attendee = model.Attendee?.Select(x => x.Id).ToList(),
            BookingReference = model.BookingReference?.Select(x => x.Id).ToList(),
            DailyEventReference = model.DailyEventReference?.ToDto(),
            DestinationCalendar = model.DestinationCalendar?.ToDto(),
            Payment = model.Payment?.Select(x => x.Id).ToList(),
            WorkflowReminder = model.WorkflowReminder?.Select(x => x.Id).ToList(),
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
