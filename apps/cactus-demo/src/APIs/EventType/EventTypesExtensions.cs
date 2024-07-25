using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class EventTypesExtensions
{
    public static EventType ToDto(this EventTypeDbModel model)
    {
        return new EventType
        {
            Id = model.Id,
            Title = model.Title,
            Slug = model.Slug,
            Description = model.Description,
            Position = model.Position,
            Locations = model.Locations,
            Length = model.Length,
            Hidden = model.Hidden,
            UserId = model.UserId,
            EventName = model.EventName,
            TimeZone = model.TimeZone,
            PeriodType = model.PeriodType,
            PeriodStartDate = model.PeriodStartDate,
            PeriodEndDate = model.PeriodEndDate,
            PeriodDays = model.PeriodDays,
            PeriodCountCalendarDays = model.PeriodCountCalendarDays,
            RequiresConfirmation = model.RequiresConfirmation,
            RecurringEvent = model.RecurringEvent,
            DisableGuests = model.DisableGuests,
            HideCalendarNotes = model.HideCalendarNotes,
            MinimumBookingNotice = model.MinimumBookingNotice,
            BeforeEventBuffer = model.BeforeEventBuffer,
            AfterEventBuffer = model.AfterEventBuffer,
            SeatsPerTimeSlot = model.SeatsPerTimeSlot,
            SchedulingType = model.SchedulingType,
            Price = model.Price,
            Currency = model.Currency,
            SlotInterval = model.SlotInterval,
            Metadata = model.Metadata,
            SuccessRedirectUrl = model.SuccessRedirectUrl,
            Schedule = model.ScheduleId,
            Team = model.TeamId,
            Users = model.Users?.Select(x => x.Id).ToList(),
            Availability = model.Availability?.Select(x => x.Id).ToList(),
            Booking = model.Booking?.Select(x => x.Id).ToList(),
            DestinationCalendar = model.DestinationCalendar?.ToDto(),
            EventTypeCustomInput = model.EventTypeCustomInput?.Select(x => x.Id).ToList(),
            HashedLink = model.HashedLink?.ToDto(),
            Webhook = model.Webhook?.Select(x => x.Id).ToList(),
            WorkflowsOnEventTypes = model.WorkflowsOnEventTypes?.Select(x => x.Id).ToList(),
        };
    }

    public static EventTypeDbModel ToModel(
        this EventTypeUpdateInput updateDto,
        EventTypeWhereUniqueInput uniqueId
    )
    {
        var eventType = new EventTypeDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            Locations = updateDto.Locations,
            UserId = updateDto.UserId,
            EventName = updateDto.EventName,
            TimeZone = updateDto.TimeZone,
            PeriodStartDate = updateDto.PeriodStartDate,
            PeriodEndDate = updateDto.PeriodEndDate,
            PeriodDays = updateDto.PeriodDays,
            PeriodCountCalendarDays = updateDto.PeriodCountCalendarDays,
            RecurringEvent = updateDto.RecurringEvent,
            SeatsPerTimeSlot = updateDto.SeatsPerTimeSlot,
            SchedulingType = updateDto.SchedulingType,
            SlotInterval = updateDto.SlotInterval,
            Metadata = updateDto.Metadata,
            SuccessRedirectUrl = updateDto.SuccessRedirectUrl
        };

        // map required fields
        if (updateDto.Title != null)
        {
            eventType.Title = updateDto.Title;
        }
        if (updateDto.Slug != null)
        {
            eventType.Slug = updateDto.Slug;
        }
        if (updateDto.Position != null)
        {
            eventType.Position = updateDto.Position.Value;
        }
        if (updateDto.Length != null)
        {
            eventType.Length = updateDto.Length.Value;
        }
        if (updateDto.Hidden != null)
        {
            eventType.Hidden = updateDto.Hidden.Value;
        }
        if (updateDto.PeriodType != null)
        {
            eventType.PeriodType = updateDto.PeriodType.Value;
        }
        if (updateDto.RequiresConfirmation != null)
        {
            eventType.RequiresConfirmation = updateDto.RequiresConfirmation.Value;
        }
        if (updateDto.DisableGuests != null)
        {
            eventType.DisableGuests = updateDto.DisableGuests.Value;
        }
        if (updateDto.HideCalendarNotes != null)
        {
            eventType.HideCalendarNotes = updateDto.HideCalendarNotes.Value;
        }
        if (updateDto.MinimumBookingNotice != null)
        {
            eventType.MinimumBookingNotice = updateDto.MinimumBookingNotice.Value;
        }
        if (updateDto.BeforeEventBuffer != null)
        {
            eventType.BeforeEventBuffer = updateDto.BeforeEventBuffer.Value;
        }
        if (updateDto.AfterEventBuffer != null)
        {
            eventType.AfterEventBuffer = updateDto.AfterEventBuffer.Value;
        }
        if (updateDto.Price != null)
        {
            eventType.Price = updateDto.Price.Value;
        }
        if (updateDto.Currency != null)
        {
            eventType.Currency = updateDto.Currency;
        }
        if (updateDto.Users != null)
        {
            eventType.Users = updateDto.Users.Value;
        }

        return eventType;
    }
}
