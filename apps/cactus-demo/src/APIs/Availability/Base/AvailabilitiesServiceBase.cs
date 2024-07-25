using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class AvailabilitiesServiceBase : IAvailabilitiesService
{
    protected readonly CactusDemoDbContext _context;

    public AvailabilitiesServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Meta data about Availability records
    /// </summary>
    public async Task<MetadataDto> AvailabilitiesMeta(AvailabilityFindManyArgs findManyArgs)
    {
        var count = await _context.Availabilities.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get a Event Type record for Availability
    /// </summary>
    public async Task<EventType> GetEventType(AvailabilityWhereUniqueInput uniqueId)
    {
        var availability = await _context
            .Availabilities.Where(availability => availability.Id == uniqueId.Id)
            .Include(availability => availability.EventType)
            .FirstOrDefaultAsync();
        if (availability == null)
        {
            throw new NotFoundException();
        }
        return availability.EventType.ToDto();
    }

    /// <summary>
    /// Get a Schedule record for Availability
    /// </summary>
    public async Task<Schedule> GetSchedule(AvailabilityWhereUniqueInput uniqueId)
    {
        var availability = await _context
            .Availabilities.Where(availability => availability.Id == uniqueId.Id)
            .Include(availability => availability.Schedule)
            .FirstOrDefaultAsync();
        if (availability == null)
        {
            throw new NotFoundException();
        }
        return availability.Schedule.ToDto();
    }

    /// <summary>
    /// Get a Users record for Availability
    /// </summary>
    public async Task<User> GetUsers(AvailabilityWhereUniqueInput uniqueId)
    {
        var availability = await _context
            .Availabilities.Where(availability => availability.Id == uniqueId.Id)
            .Include(availability => availability.Users)
            .FirstOrDefaultAsync();
        if (availability == null)
        {
            throw new NotFoundException();
        }
        return availability.Users.ToDto();
    }

    /// <summary>
    /// Create one Availability
    /// </summary>
    public async Task<Availability> CreateAvailability(AvailabilityCreateInput createDto)
    {
        var availability = new AvailabilityDbModel
        {
            Days = createDto.Days,
            StartTime = createDto.StartTime,
            EndTime = createDto.EndTime,
            Date = createDto.Date
        };

        if (createDto.Id != null)
        {
            availability.Id = createDto.Id.Value;
        }
        if (createDto.EventType != null)
        {
            availability.EventType = await _context
                .EventTypes.Where(eventType => createDto.EventType.Id == eventType.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Schedule != null)
        {
            availability.Schedule = await _context
                .Schedules.Where(schedule => createDto.Schedule.Id == schedule.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Users != null)
        {
            availability.Users = await _context
                .Users.Where(user => createDto.Users.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Availabilities.Add(availability);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AvailabilityDbModel>(availability.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Availability
    /// </summary>
    public async Task DeleteAvailability(AvailabilityWhereUniqueInput uniqueId)
    {
        var availability = await _context.Availabilities.FindAsync(uniqueId.Id);
        if (availability == null)
        {
            throw new NotFoundException();
        }

        _context.Availabilities.Remove(availability);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Availabilities
    /// </summary>
    public async Task<List<Availability>> Availabilities(AvailabilityFindManyArgs findManyArgs)
    {
        var availabilities = await _context
            .Availabilities.Include(x => x.EventType)
            .Include(x => x.Schedule)
            .Include(x => x.Users)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return availabilities.ConvertAll(availability => availability.ToDto());
    }

    /// <summary>
    /// Get one Availability
    /// </summary>
    public async Task<Availability> Availability(AvailabilityWhereUniqueInput uniqueId)
    {
        var availabilities = await this.Availabilities(
            new AvailabilityFindManyArgs { Where = new AvailabilityWhereInput { Id = uniqueId.Id } }
        );
        var availability = availabilities.FirstOrDefault();
        if (availability == null)
        {
            throw new NotFoundException();
        }

        return availability;
    }

    /// <summary>
    /// Update one Availability
    /// </summary>
    public async Task UpdateAvailability(
        AvailabilityWhereUniqueInput uniqueId,
        AvailabilityUpdateInput updateDto
    )
    {
        var availability = updateDto.ToModel(uniqueId);

        _context.Entry(availability).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Availabilities.Any(e => e.Id == availability.Id))
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
