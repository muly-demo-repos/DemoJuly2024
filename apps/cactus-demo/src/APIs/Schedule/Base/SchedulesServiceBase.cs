using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class SchedulesServiceBase : ISchedulesService
{
    protected readonly CactusDemoDbContext _context;

    public SchedulesServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Schedule
    /// </summary>
    public async Task<Schedule> CreateSchedule(ScheduleCreateInput createDto)
    {
        var schedule = new ScheduleDbModel { Name = createDto.Name, TimeZone = createDto.TimeZone };

        if (createDto.Id != null)
        {
            schedule.Id = createDto.Id.Value;
        }
        if (createDto.Availability != null)
        {
            schedule.Availability = await _context
                .Availabilities.Where(availability =>
                    createDto.Availability.Select(t => t.Id).Contains(availability.Id)
                )
                .ToListAsync();
        }

        if (createDto.EventType != null)
        {
            schedule.EventType = await _context
                .EventTypes.Where(eventType =>
                    createDto.EventType.Select(t => t.Id).Contains(eventType.Id)
                )
                .ToListAsync();
        }

        if (createDto.Users != null)
        {
            schedule.Users = await _context
                .Users.Where(user => createDto.Users.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ScheduleDbModel>(schedule.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Schedule
    /// </summary>
    public async Task DeleteSchedule(ScheduleWhereUniqueInput uniqueId)
    {
        var schedule = await _context.Schedules.FindAsync(uniqueId.Id);
        if (schedule == null)
        {
            throw new NotFoundException();
        }

        _context.Schedules.Remove(schedule);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Schedules
    /// </summary>
    public async Task<List<Schedule>> Schedules(ScheduleFindManyArgs findManyArgs)
    {
        var schedules = await _context
            .Schedules.Include(x => x.Availability)
            .Include(x => x.EventType)
            .Include(x => x.Users)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return schedules.ConvertAll(schedule => schedule.ToDto());
    }

    /// <summary>
    /// Get one Schedule
    /// </summary>
    public async Task<Schedule> Schedule(ScheduleWhereUniqueInput uniqueId)
    {
        var schedules = await this.Schedules(
            new ScheduleFindManyArgs { Where = new ScheduleWhereInput { Id = uniqueId.Id } }
        );
        var schedule = schedules.FirstOrDefault();
        if (schedule == null)
        {
            throw new NotFoundException();
        }

        return schedule;
    }

    /// <summary>
    /// Connect multiple Availability records to Schedule
    /// </summary>
    public async Task ConnectAvailability(
        ScheduleWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        var schedule = await _context
            .Schedules.Include(x => x.Availability)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (schedule == null)
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

        var availabilitiesToConnect = availabilities.Except(schedule.Availability);

        foreach (var availability in availabilitiesToConnect)
        {
            schedule.Availability.Add(availability);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Event Type records to Schedule
    /// </summary>
    public async Task ConnectEventType(
        ScheduleWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var schedule = await _context
            .Schedules.Include(x => x.EventType)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (schedule == null)
        {
            throw new NotFoundException();
        }

        var eventTypes = await _context
            .EventTypes.Where(t => eventTypesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (eventTypes.Count == 0)
        {
            throw new NotFoundException();
        }

        var eventTypesToConnect = eventTypes.Except(schedule.EventType);

        foreach (var eventType in eventTypesToConnect)
        {
            schedule.EventType.Add(eventType);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Availability records from Schedule
    /// </summary>
    public async Task DisconnectAvailability(
        ScheduleWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        var schedule = await _context
            .Schedules.Include(x => x.Availability)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (schedule == null)
        {
            throw new NotFoundException();
        }

        var availabilities = await _context
            .Availabilities.Where(t => availabilitiesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var availability in availabilities)
        {
            schedule.Availability?.Remove(availability);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Event Type records from Schedule
    /// </summary>
    public async Task DisconnectEventType(
        ScheduleWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var schedule = await _context
            .Schedules.Include(x => x.EventType)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (schedule == null)
        {
            throw new NotFoundException();
        }

        var eventTypes = await _context
            .EventTypes.Where(t => eventTypesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var eventType in eventTypes)
        {
            schedule.EventType?.Remove(eventType);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Availability records for Schedule
    /// </summary>
    public async Task<List<Availability>> FindAvailability(
        ScheduleWhereUniqueInput uniqueId,
        AvailabilityFindManyArgs scheduleFindManyArgs
    )
    {
        var availabilities = await _context
            .Availabilities.Where(m => m.ScheduleId == uniqueId.Id)
            .ApplyWhere(scheduleFindManyArgs.Where)
            .ApplySkip(scheduleFindManyArgs.Skip)
            .ApplyTake(scheduleFindManyArgs.Take)
            .ApplyOrderBy(scheduleFindManyArgs.SortBy)
            .ToListAsync();

        return availabilities.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Event Type records for Schedule
    /// </summary>
    public async Task<List<EventType>> FindEventType(
        ScheduleWhereUniqueInput uniqueId,
        EventTypeFindManyArgs scheduleFindManyArgs
    )
    {
        var eventTypes = await _context
            .EventTypes.Where(m => m.ScheduleId == uniqueId.Id)
            .ApplyWhere(scheduleFindManyArgs.Where)
            .ApplySkip(scheduleFindManyArgs.Skip)
            .ApplyTake(scheduleFindManyArgs.Take)
            .ApplyOrderBy(scheduleFindManyArgs.SortBy)
            .ToListAsync();

        return eventTypes.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Get a Users record for Schedule
    /// </summary>
    public async Task<User> GetUsers(ScheduleWhereUniqueInput uniqueId)
    {
        var schedule = await _context
            .Schedules.Where(schedule => schedule.Id == uniqueId.Id)
            .Include(schedule => schedule.Users)
            .FirstOrDefaultAsync();
        if (schedule == null)
        {
            throw new NotFoundException();
        }
        return schedule.Users.ToDto();
    }

    /// <summary>
    /// Meta data about Schedule records
    /// </summary>
    public async Task<MetadataDto> SchedulesMeta(ScheduleFindManyArgs findManyArgs)
    {
        var count = await _context.Schedules.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Availability records for Schedule
    /// </summary>
    public async Task UpdateAvailability(
        ScheduleWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        var schedule = await _context
            .Schedules.Include(t => t.Availability)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (schedule == null)
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

        schedule.Availability = availabilities;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Event Type records for Schedule
    /// </summary>
    public async Task UpdateEventType(
        ScheduleWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var schedule = await _context
            .Schedules.Include(t => t.EventType)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (schedule == null)
        {
            throw new NotFoundException();
        }

        var eventTypes = await _context
            .EventTypes.Where(a => eventTypesId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (eventTypes.Count == 0)
        {
            throw new NotFoundException();
        }

        schedule.EventType = eventTypes;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update one Schedule
    /// </summary>
    public async Task UpdateSchedule(
        ScheduleWhereUniqueInput uniqueId,
        ScheduleUpdateInput updateDto
    )
    {
        var schedule = updateDto.ToModel(uniqueId);

        if (updateDto.Availability != null)
        {
            schedule.Availability = await _context
                .Availabilities.Where(availability =>
                    updateDto.Availability.Select(t => t).Contains(availability.Id)
                )
                .ToListAsync();
        }

        if (updateDto.EventType != null)
        {
            schedule.EventType = await _context
                .EventTypes.Where(eventType =>
                    updateDto.EventType.Select(t => t).Contains(eventType.Id)
                )
                .ToListAsync();
        }

        _context.Entry(schedule).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Schedules.Any(e => e.Id == schedule.Id))
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
