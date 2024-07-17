using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class EventTypesServiceBase : IEventTypesService
{
    protected readonly CactusDemoDbContext _context;

    public EventTypesServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Event Type
    /// </summary>
    public async Task<EventType> CreateEventType(EventTypeCreateInput createDto)
    {
        var eventType = new EventTypeDbModel
        {
            Title = createDto.Title,
            Slug = createDto.Slug,
            Description = createDto.Description,
            Position = createDto.Position,
            Locations = createDto.Locations,
            Length = createDto.Length,
            Hidden = createDto.Hidden,
            UserId = createDto.UserId,
            EventName = createDto.EventName,
            TimeZone = createDto.TimeZone,
            PeriodType = createDto.PeriodType,
            PeriodStartDate = createDto.PeriodStartDate,
            PeriodEndDate = createDto.PeriodEndDate,
            PeriodDays = createDto.PeriodDays,
            PeriodCountCalendarDays = createDto.PeriodCountCalendarDays,
            RequiresConfirmation = createDto.RequiresConfirmation,
            RecurringEvent = createDto.RecurringEvent,
            DisableGuests = createDto.DisableGuests,
            HideCalendarNotes = createDto.HideCalendarNotes,
            MinimumBookingNotice = createDto.MinimumBookingNotice,
            BeforeEventBuffer = createDto.BeforeEventBuffer,
            AfterEventBuffer = createDto.AfterEventBuffer,
            SeatsPerTimeSlot = createDto.SeatsPerTimeSlot,
            SchedulingType = createDto.SchedulingType,
            Price = createDto.Price,
            Currency = createDto.Currency,
            SlotInterval = createDto.SlotInterval,
            Metadata = createDto.Metadata,
            SuccessRedirectUrl = createDto.SuccessRedirectUrl
        };

        if (createDto.Id != null)
        {
            eventType.Id = createDto.Id.Value;
        }
        if (createDto.Availability != null)
        {
            eventType.Availability = await _context
                .Availabilities.Where(availability =>
                    createDto.Availability.Select(t => t.Id).Contains(availability.Id)
                )
                .ToListAsync();
        }

        if (createDto.Booking != null)
        {
            eventType.Booking = await _context
                .Bookings.Where(booking => createDto.Booking.Select(t => t.Id).Contains(booking.Id))
                .ToListAsync();
        }

        if (createDto.DestinationCalendar != null)
        {
            eventType.DestinationCalendar = await _context
                .DestinationCalendars.Where(destinationCalendar =>
                    createDto.DestinationCalendar.Id == destinationCalendar.Id
                )
                .FirstOrDefaultAsync();
        }

        if (createDto.EventTypeCustomInput != null)
        {
            eventType.EventTypeCustomInput = await _context
                .EventTypeCustomInputs.Where(eventTypeCustomInput =>
                    createDto
                        .EventTypeCustomInput.Select(t => t.Id)
                        .Contains(eventTypeCustomInput.Id)
                )
                .ToListAsync();
        }

        if (createDto.HashedLink != null)
        {
            eventType.HashedLink = await _context
                .HashedLinks.Where(hashedLink => createDto.HashedLink.Id == hashedLink.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Schedule != null)
        {
            eventType.Schedule = await _context
                .Schedules.Where(schedule => createDto.Schedule.Id == schedule.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Team != null)
        {
            eventType.Team = await _context
                .Teams.Where(team => createDto.Team.Id == team.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Webhook != null)
        {
            eventType.Webhook = await _context
                .Webhooks.Where(webhook => createDto.Webhook.Select(t => t.Id).Contains(webhook.Id))
                .ToListAsync();
        }

        if (createDto.WorkflowsOnEventTypes != null)
        {
            eventType.WorkflowsOnEventTypes = await _context
                .WorkflowsOnEventTypes.Where(workflowsOnEventType =>
                    createDto
                        .WorkflowsOnEventTypes.Select(t => t.Id)
                        .Contains(workflowsOnEventType.Id)
                )
                .ToListAsync();
        }

        if (createDto.Users != null)
        {
            eventType.Users = await _context
                .Users.Where(user => createDto.Users.Select(t => t.Id).Contains(user.Id))
                .ToListAsync();
        }

        _context.EventTypes.Add(eventType);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<EventTypeDbModel>(eventType.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Event Type
    /// </summary>
    public async Task DeleteEventType(EventTypeWhereUniqueInput uniqueId)
    {
        var eventType = await _context.EventTypes.FindAsync(uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        _context.EventTypes.Remove(eventType);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Availability records to Event Type
    /// </summary>
    public async Task ConnectAvailability(
        EventTypeWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Availability)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var availabilities = await _context
            .Availabilities.Where(t => availabilitiesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (availabilities.Count == 0)
        {
            throw new NotFoundException();
        }

        var availabilitiesToConnect = availabilities.Except(eventType.Availability);

        foreach (var availability in availabilitiesToConnect)
        {
            eventType.Availability.Add(availability);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Booking records to Event Type
    /// </summary>
    public async Task ConnectBooking(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Booking)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var bookings = await _context
            .Bookings.Where(t => bookingsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (bookings.Count == 0)
        {
            throw new NotFoundException();
        }

        var bookingsToConnect = bookings.Except(eventType.Booking);

        foreach (var booking in bookingsToConnect)
        {
            eventType.Booking.Add(booking);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Event Type Custom Input records to Event Type
    /// </summary>
    public async Task ConnectEventTypeCustomInput(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.EventTypeCustomInput)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var eventTypeCustomInputs = await _context
            .EventTypeCustomInputs.Where(t =>
                eventTypeCustomInputsId.Select(x => x.Id).Contains(t.Id)
            )
            .ToListAsync();
        if (eventTypeCustomInputs.Count == 0)
        {
            throw new NotFoundException();
        }

        var eventTypeCustomInputsToConnect = eventTypeCustomInputs.Except(
            eventType.EventTypeCustomInput
        );

        foreach (var eventTypeCustomInput in eventTypeCustomInputsToConnect)
        {
            eventType.EventTypeCustomInput.Add(eventTypeCustomInput);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Users records to Event Type
    /// </summary>
    public async Task ConnectUsers(
        EventTypeWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] usersId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var users = await _context
            .Users.Where(t => usersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (users.Count == 0)
        {
            throw new NotFoundException();
        }

        var usersToConnect = users.Except(eventType.Users);

        foreach (var user in usersToConnect)
        {
            eventType.Users.Add(user);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Webhook records to Event Type
    /// </summary>
    public async Task ConnectWebhook(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Webhook)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var webhooks = await _context
            .Webhooks.Where(t => webhooksId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (webhooks.Count == 0)
        {
            throw new NotFoundException();
        }

        var webhooksToConnect = webhooks.Except(eventType.Webhook);

        foreach (var webhook in webhooksToConnect)
        {
            eventType.Webhook.Add(webhook);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Workflows On Event Types records to Event Type
    /// </summary>
    public async Task ConnectWorkflowsOnEventTypes(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.WorkflowsOnEventTypes)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var workflowsOnEventTypes = await _context
            .WorkflowsOnEventTypes.Where(t =>
                workflowsOnEventTypesId.Select(x => x.Id).Contains(t.Id)
            )
            .ToListAsync();
        if (workflowsOnEventTypes.Count == 0)
        {
            throw new NotFoundException();
        }

        var workflowsOnEventTypesToConnect = workflowsOnEventTypes.Except(
            eventType.WorkflowsOnEventTypes
        );

        foreach (var workflowsOnEventType in workflowsOnEventTypesToConnect)
        {
            eventType.WorkflowsOnEventTypes.Add(workflowsOnEventType);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Availability records from Event Type
    /// </summary>
    public async Task DisconnectAvailability(
        EventTypeWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Availability)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var availabilities = await _context
            .Availabilities.Where(t => availabilitiesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var availability in availabilities)
        {
            eventType.Availability?.Remove(availability);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Booking records from Event Type
    /// </summary>
    public async Task DisconnectBooking(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Booking)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var bookings = await _context
            .Bookings.Where(t => bookingsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var booking in bookings)
        {
            eventType.Booking?.Remove(booking);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Event Type Custom Input records from Event Type
    /// </summary>
    public async Task DisconnectEventTypeCustomInput(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.EventTypeCustomInput)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var eventTypeCustomInputs = await _context
            .EventTypeCustomInputs.Where(t =>
                eventTypeCustomInputsId.Select(x => x.Id).Contains(t.Id)
            )
            .ToListAsync();

        foreach (var eventTypeCustomInput in eventTypeCustomInputs)
        {
            eventType.EventTypeCustomInput?.Remove(eventTypeCustomInput);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Users records from Event Type
    /// </summary>
    public async Task DisconnectUsers(
        EventTypeWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] usersId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var users = await _context
            .Users.Where(t => usersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var user in users)
        {
            eventType.Users?.Remove(user);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Webhook records from Event Type
    /// </summary>
    public async Task DisconnectWebhook(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Webhook)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var webhooks = await _context
            .Webhooks.Where(t => webhooksId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var webhook in webhooks)
        {
            eventType.Webhook?.Remove(webhook);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Workflows On Event Types records from Event Type
    /// </summary>
    public async Task DisconnectWorkflowsOnEventTypes(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.WorkflowsOnEventTypes)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var workflowsOnEventTypes = await _context
            .WorkflowsOnEventTypes.Where(t =>
                workflowsOnEventTypesId.Select(x => x.Id).Contains(t.Id)
            )
            .ToListAsync();

        foreach (var workflowsOnEventType in workflowsOnEventTypes)
        {
            eventType.WorkflowsOnEventTypes?.Remove(workflowsOnEventType);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Availability records for Event Type
    /// </summary>
    public async Task<List<Availability>> FindAvailability(
        EventTypeWhereUniqueInput uniqueId,
        AvailabilityFindManyArgs eventTypeFindManyArgs
    )
    {
        var availabilities = await _context
            .Availabilities.Where(m => m.EventTypeId == uniqueId.Id)
            .ApplyWhere(eventTypeFindManyArgs.Where)
            .ApplySkip(eventTypeFindManyArgs.Skip)
            .ApplyTake(eventTypeFindManyArgs.Take)
            .ApplyOrderBy(eventTypeFindManyArgs.SortBy)
            .ToListAsync();

        return availabilities.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Booking records for Event Type
    /// </summary>
    public async Task<List<Booking>> FindBooking(
        EventTypeWhereUniqueInput uniqueId,
        BookingFindManyArgs eventTypeFindManyArgs
    )
    {
        var bookings = await _context
            .Bookings.Where(m => m.EventTypeId == uniqueId.Id)
            .ApplyWhere(eventTypeFindManyArgs.Where)
            .ApplySkip(eventTypeFindManyArgs.Skip)
            .ApplyTake(eventTypeFindManyArgs.Take)
            .ApplyOrderBy(eventTypeFindManyArgs.SortBy)
            .ToListAsync();

        return bookings.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Event Type Custom Input records for Event Type
    /// </summary>
    public async Task<List<EventTypeCustomInput>> FindEventTypeCustomInput(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputFindManyArgs eventTypeFindManyArgs
    )
    {
        var eventTypeCustomInputs = await _context
            .EventTypeCustomInputs.Where(m => m.EventTypeId == uniqueId.Id)
            .ApplyWhere(eventTypeFindManyArgs.Where)
            .ApplySkip(eventTypeFindManyArgs.Skip)
            .ApplyTake(eventTypeFindManyArgs.Take)
            .ApplyOrderBy(eventTypeFindManyArgs.SortBy)
            .ToListAsync();

        return eventTypeCustomInputs.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Users records for Event Type
    /// </summary>
    public async Task<List<User>> FindUsers(
        EventTypeWhereUniqueInput uniqueId,
        UserFindManyArgs eventTypeFindManyArgs
    )
    {
        var users = await _context
            .Users.Where(m => m.EventType.Any(x => x.Id == uniqueId.Id))
            .ApplyWhere(eventTypeFindManyArgs.Where)
            .ApplySkip(eventTypeFindManyArgs.Skip)
            .ApplyTake(eventTypeFindManyArgs.Take)
            .ApplyOrderBy(eventTypeFindManyArgs.SortBy)
            .ToListAsync();

        return users.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Webhook records for Event Type
    /// </summary>
    public async Task<List<Webhook>> FindWebhook(
        EventTypeWhereUniqueInput uniqueId,
        WebhookFindManyArgs eventTypeFindManyArgs
    )
    {
        var webhooks = await _context
            .Webhooks.Where(m => m.EventTypeId == uniqueId.Id)
            .ApplyWhere(eventTypeFindManyArgs.Where)
            .ApplySkip(eventTypeFindManyArgs.Skip)
            .ApplyTake(eventTypeFindManyArgs.Take)
            .ApplyOrderBy(eventTypeFindManyArgs.SortBy)
            .ToListAsync();

        return webhooks.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Workflows On Event Types records for Event Type
    /// </summary>
    public async Task<List<WorkflowsOnEventType>> FindWorkflowsOnEventTypes(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeFindManyArgs eventTypeFindManyArgs
    )
    {
        var workflowsOnEventTypes = await _context
            .WorkflowsOnEventTypes.Where(m => m.EventTypeId == uniqueId.Id)
            .ApplyWhere(eventTypeFindManyArgs.Where)
            .ApplySkip(eventTypeFindManyArgs.Skip)
            .ApplyTake(eventTypeFindManyArgs.Take)
            .ApplyOrderBy(eventTypeFindManyArgs.SortBy)
            .ToListAsync();

        return workflowsOnEventTypes.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Get a Destination Calendar record for Event Type
    /// </summary>
    public async Task<DestinationCalendar> GetDestinationCalendar(
        EventTypeWhereUniqueInput uniqueId
    )
    {
        var eventType = await _context
            .EventTypes.Where(eventType => eventType.Id == uniqueId.Id)
            .Include(eventType => eventType.DestinationCalendar)
            .FirstOrDefaultAsync();
        if (eventType == null)
        {
            throw new NotFoundException();
        }
        return eventType.DestinationCalendar.ToDto();
    }

    /// <summary>
    /// Get a Hashed Link record for Event Type
    /// </summary>
    public async Task<HashedLink> GetHashedLink(EventTypeWhereUniqueInput uniqueId)
    {
        var eventType = await _context
            .EventTypes.Where(eventType => eventType.Id == uniqueId.Id)
            .Include(eventType => eventType.HashedLink)
            .FirstOrDefaultAsync();
        if (eventType == null)
        {
            throw new NotFoundException();
        }
        return eventType.HashedLink.ToDto();
    }

    /// <summary>
    /// Get a Schedule record for Event Type
    /// </summary>
    public async Task<Schedule> GetSchedule(EventTypeWhereUniqueInput uniqueId)
    {
        var eventType = await _context
            .EventTypes.Where(eventType => eventType.Id == uniqueId.Id)
            .Include(eventType => eventType.Schedule)
            .FirstOrDefaultAsync();
        if (eventType == null)
        {
            throw new NotFoundException();
        }
        return eventType.Schedule.ToDto();
    }

    /// <summary>
    /// Get a Team record for Event Type
    /// </summary>
    public async Task<Team> GetTeam(EventTypeWhereUniqueInput uniqueId)
    {
        var eventType = await _context
            .EventTypes.Where(eventType => eventType.Id == uniqueId.Id)
            .Include(eventType => eventType.Team)
            .FirstOrDefaultAsync();
        if (eventType == null)
        {
            throw new NotFoundException();
        }
        return eventType.Team.ToDto();
    }

    /// <summary>
    /// Meta data about Event Type records
    /// </summary>
    public async Task<MetadataDto> EventTypesMeta(EventTypeFindManyArgs findManyArgs)
    {
        var count = await _context.EventTypes.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Availability records for Event Type
    /// </summary>
    public async Task UpdateAvailability(
        EventTypeWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        var eventType = await _context
            .EventTypes.Include(t => t.Availability)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var availabilities = await _context
            .Availabilities.Where(a => availabilitiesId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (availabilities.Count == 0)
        {
            throw new NotFoundException();
        }

        eventType.Availability = availabilities;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Booking records for Event Type
    /// </summary>
    public async Task UpdateBooking(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(t => t.Booking)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var bookings = await _context
            .Bookings.Where(a => bookingsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (bookings.Count == 0)
        {
            throw new NotFoundException();
        }

        eventType.Booking = bookings;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Event Type Custom Input records for Event Type
    /// </summary>
    public async Task UpdateEventTypeCustomInput(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(t => t.EventTypeCustomInput)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var eventTypeCustomInputs = await _context
            .EventTypeCustomInputs.Where(a =>
                eventTypeCustomInputsId.Select(x => x.Id).Contains(a.Id)
            )
            .ToListAsync();

        if (eventTypeCustomInputs.Count == 0)
        {
            throw new NotFoundException();
        }

        eventType.EventTypeCustomInput = eventTypeCustomInputs;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Users records for Event Type
    /// </summary>
    public async Task UpdateUsers(
        EventTypeWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] usersId
    )
    {
        var eventType = await _context
            .EventTypes.Include(t => t.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var users = await _context
            .Users.Where(a => usersId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (users.Count == 0)
        {
            throw new NotFoundException();
        }

        eventType.Users = users;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Webhook records for Event Type
    /// </summary>
    public async Task UpdateWebhook(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var eventType = await _context
            .EventTypes.Include(t => t.Webhook)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var webhooks = await _context
            .Webhooks.Where(a => webhooksId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (webhooks.Count == 0)
        {
            throw new NotFoundException();
        }

        eventType.Webhook = webhooks;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Workflows On Event Types records for Event Type
    /// </summary>
    public async Task UpdateWorkflowsOnEventTypes(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var eventType = await _context
            .EventTypes.Include(t => t.WorkflowsOnEventTypes)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        var workflowsOnEventTypes = await _context
            .WorkflowsOnEventTypes.Where(a =>
                workflowsOnEventTypesId.Select(x => x.Id).Contains(a.Id)
            )
            .ToListAsync();

        if (workflowsOnEventTypes.Count == 0)
        {
            throw new NotFoundException();
        }

        eventType.WorkflowsOnEventTypes = workflowsOnEventTypes;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many EventTypes
    /// </summary>
    public async Task<List<EventType>> EventTypes(EventTypeFindManyArgs findManyArgs)
    {
        var eventTypes = await _context
            .EventTypes.Include(x => x.Availability)
            .Include(x => x.Booking)
            .Include(x => x.DestinationCalendar)
            .Include(x => x.EventTypeCustomInput)
            .Include(x => x.HashedLink)
            .Include(x => x.Schedule)
            .Include(x => x.Team)
            .Include(x => x.Webhook)
            .Include(x => x.WorkflowsOnEventTypes)
            .Include(x => x.Users)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return eventTypes.ConvertAll(eventType => eventType.ToDto());
    }

    /// <summary>
    /// Get one Event Type
    /// </summary>
    public async Task<EventType> EventType(EventTypeWhereUniqueInput uniqueId)
    {
        var eventTypes = await this.EventTypes(
            new EventTypeFindManyArgs { Where = new EventTypeWhereInput { Id = uniqueId.Id } }
        );
        var eventType = eventTypes.FirstOrDefault();
        if (eventType == null)
        {
            throw new NotFoundException();
        }

        return eventType;
    }

    /// <summary>
    /// Update one Event Type
    /// </summary>
    public async Task UpdateEventType(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeUpdateInput updateDto
    )
    {
        var eventType = updateDto.ToModel(uniqueId);

        if (updateDto.Availability != null)
        {
            eventType.Availability = await _context
                .Availabilities.Where(availability =>
                    updateDto.Availability.Select(t => t).Contains(availability.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Booking != null)
        {
            eventType.Booking = await _context
                .Bookings.Where(booking => updateDto.Booking.Select(t => t).Contains(booking.Id))
                .ToListAsync();
        }

        if (updateDto.EventTypeCustomInput != null)
        {
            eventType.EventTypeCustomInput = await _context
                .EventTypeCustomInputs.Where(eventTypeCustomInput =>
                    updateDto.EventTypeCustomInput.Select(t => t).Contains(eventTypeCustomInput.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Webhook != null)
        {
            eventType.Webhook = await _context
                .Webhooks.Where(webhook => updateDto.Webhook.Select(t => t).Contains(webhook.Id))
                .ToListAsync();
        }

        if (updateDto.WorkflowsOnEventTypes != null)
        {
            eventType.WorkflowsOnEventTypes = await _context
                .WorkflowsOnEventTypes.Where(workflowsOnEventType =>
                    updateDto.WorkflowsOnEventTypes.Select(t => t).Contains(workflowsOnEventType.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Users != null)
        {
            eventType.Users = await _context
                .Users.Where(user => updateDto.Users.Select(t => t).Contains(user.Id))
                .ToListAsync();
        }

        _context.Entry(eventType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.EventTypes.Any(e => e.Id == eventType.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
