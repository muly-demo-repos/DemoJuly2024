using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class EventTypesServiceBase : IEventTypesService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public EventTypesServiceBase(CactusDemoDotnetDbContext context)
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
        if (createDto.DestinationCalendar != null)
        {
            eventType.DestinationCalendar = await _context
                .DestinationCalendars.Where(destinationCalendar =>
                    createDto.DestinationCalendar.Id == destinationCalendar.Id
                )
                .FirstOrDefaultAsync();
        }

        if (createDto.Users != null)
        {
            eventType.Users = await _context
                .Users.Where(user => createDto.Users.Select(t => t.Id).Contains(user.Id))
                .ToListAsync();
        }

        if (createDto.Team != null)
        {
            eventType.Team = await _context
                .Teams.Where(team => createDto.Team.Id == team.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Bookings != null)
        {
            eventType.Bookings = await _context
                .Bookings.Where(booking =>
                    createDto.Bookings.Select(t => t.Id).Contains(booking.Id)
                )
                .ToListAsync();
        }

        if (createDto.Schedule != null)
        {
            eventType.Schedule = await _context
                .Schedules.Where(schedule => createDto.Schedule.Id == schedule.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Availability != null)
        {
            eventType.Availability = await _context
                .Availabilities.Where(availability =>
                    createDto.Availability.Select(t => t.Id).Contains(availability.Id)
                )
                .ToListAsync();
        }

        if (createDto.CustomInputs != null)
        {
            eventType.CustomInputs = await _context
                .EventTypeCustomInputs.Where(eventTypeCustomInput =>
                    createDto.CustomInputs.Select(t => t.Id).Contains(eventTypeCustomInput.Id)
                )
                .ToListAsync();
        }

        if (createDto.Webhooks != null)
        {
            eventType.Webhooks = await _context
                .Webhooks.Where(webhook =>
                    createDto.Webhooks.Select(t => t.Id).Contains(webhook.Id)
                )
                .ToListAsync();
        }

        if (createDto.HashedLink != null)
        {
            eventType.HashedLink = await _context
                .HashedLinks.Where(hashedLink => createDto.HashedLink.Id == hashedLink.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Workflows != null)
        {
            eventType.Workflows = await _context
                .WorkflowsOnEventTypes.Where(workflowsOnEventType =>
                    createDto.Workflows.Select(t => t.Id).Contains(workflowsOnEventType.Id)
                )
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
    /// Connect multiple Bookings records to Event Type
    /// </summary>
    public async Task ConnectBookings(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Bookings)
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

        var bookingsToConnect = bookings.Except(eventType.Bookings);

        foreach (var booking in bookingsToConnect)
        {
            eventType.Bookings.Add(booking);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Custom Inputs records to Event Type
    /// </summary>
    public async Task ConnectCustomInputs(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.CustomInputs)
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

        var eventTypeCustomInputsToConnect = eventTypeCustomInputs.Except(eventType.CustomInputs);

        foreach (var eventTypeCustomInput in eventTypeCustomInputsToConnect)
        {
            eventType.CustomInputs.Add(eventTypeCustomInput);
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
    /// Connect multiple Webhooks records to Event Type
    /// </summary>
    public async Task ConnectWebhooks(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Webhooks)
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

        var webhooksToConnect = webhooks.Except(eventType.Webhooks);

        foreach (var webhook in webhooksToConnect)
        {
            eventType.Webhooks.Add(webhook);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Workflows records to Event Type
    /// </summary>
    public async Task ConnectWorkflows(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Workflows)
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

        var workflowsOnEventTypesToConnect = workflowsOnEventTypes.Except(eventType.Workflows);

        foreach (var workflowsOnEventType in workflowsOnEventTypesToConnect)
        {
            eventType.Workflows.Add(workflowsOnEventType);
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
    /// Disconnect multiple Bookings records from Event Type
    /// </summary>
    public async Task DisconnectBookings(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Bookings)
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
            eventType.Bookings?.Remove(booking);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Custom Inputs records from Event Type
    /// </summary>
    public async Task DisconnectCustomInputs(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.CustomInputs)
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
            eventType.CustomInputs?.Remove(eventTypeCustomInput);
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
    /// Disconnect multiple Webhooks records from Event Type
    /// </summary>
    public async Task DisconnectWebhooks(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Webhooks)
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
            eventType.Webhooks?.Remove(webhook);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Workflows records from Event Type
    /// </summary>
    public async Task DisconnectWorkflows(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var eventType = await _context
            .EventTypes.Include(x => x.Workflows)
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
            eventType.Workflows?.Remove(workflowsOnEventType);
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
    /// Find multiple Bookings records for Event Type
    /// </summary>
    public async Task<List<Booking>> FindBookings(
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
    /// Find multiple Custom Inputs records for Event Type
    /// </summary>
    public async Task<List<EventTypeCustomInput>> FindCustomInputs(
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
            .Users.Where(m => m.EventTypes.Any(x => x.Id == uniqueId.Id))
            .ApplyWhere(eventTypeFindManyArgs.Where)
            .ApplySkip(eventTypeFindManyArgs.Skip)
            .ApplyTake(eventTypeFindManyArgs.Take)
            .ApplyOrderBy(eventTypeFindManyArgs.SortBy)
            .ToListAsync();

        return users.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Webhooks records for Event Type
    /// </summary>
    public async Task<List<Webhook>> FindWebhooks(
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
    /// Find multiple Workflows records for Event Type
    /// </summary>
    public async Task<List<WorkflowsOnEventType>> FindWorkflows(
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
    /// Update multiple Bookings records for Event Type
    /// </summary>
    public async Task UpdateBookings(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(t => t.Bookings)
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

        eventType.Bookings = bookings;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Custom Inputs records for Event Type
    /// </summary>
    public async Task UpdateCustomInputs(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        var eventType = await _context
            .EventTypes.Include(t => t.CustomInputs)
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

        eventType.CustomInputs = eventTypeCustomInputs;
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
    /// Update multiple Webhooks records for Event Type
    /// </summary>
    public async Task UpdateWebhooks(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var eventType = await _context
            .EventTypes.Include(t => t.Webhooks)
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

        eventType.Webhooks = webhooks;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Workflows records for Event Type
    /// </summary>
    public async Task UpdateWorkflows(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var eventType = await _context
            .EventTypes.Include(t => t.Workflows)
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

        eventType.Workflows = workflowsOnEventTypes;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many EventTypes
    /// </summary>
    public async Task<List<EventType>> EventTypes(EventTypeFindManyArgs findManyArgs)
    {
        var eventTypes = await _context
            .EventTypes.Include(x => x.DestinationCalendar)
            .Include(x => x.Users)
            .Include(x => x.Team)
            .Include(x => x.Bookings)
            .Include(x => x.Schedule)
            .Include(x => x.Availability)
            .Include(x => x.CustomInputs)
            .Include(x => x.Webhooks)
            .Include(x => x.HashedLink)
            .Include(x => x.Workflows)
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

        if (updateDto.Users != null)
        {
            eventType.Users = await _context
                .Users.Where(user => updateDto.Users.Select(t => t).Contains(user.Id))
                .ToListAsync();
        }

        if (updateDto.Bookings != null)
        {
            eventType.Bookings = await _context
                .Bookings.Where(booking => updateDto.Bookings.Select(t => t).Contains(booking.Id))
                .ToListAsync();
        }

        if (updateDto.Availability != null)
        {
            eventType.Availability = await _context
                .Availabilities.Where(availability =>
                    updateDto.Availability.Select(t => t).Contains(availability.Id)
                )
                .ToListAsync();
        }

        if (updateDto.CustomInputs != null)
        {
            eventType.CustomInputs = await _context
                .EventTypeCustomInputs.Where(eventTypeCustomInput =>
                    updateDto.CustomInputs.Select(t => t).Contains(eventTypeCustomInput.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Webhooks != null)
        {
            eventType.Webhooks = await _context
                .Webhooks.Where(webhook => updateDto.Webhooks.Select(t => t).Contains(webhook.Id))
                .ToListAsync();
        }

        if (updateDto.Workflows != null)
        {
            eventType.Workflows = await _context
                .WorkflowsOnEventTypes.Where(workflowsOnEventType =>
                    updateDto.Workflows.Select(t => t).Contains(workflowsOnEventType.Id)
                )
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
