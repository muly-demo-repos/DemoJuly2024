using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class DestinationCalendarsServiceBase : IDestinationCalendarsService
{
    protected readonly CactusDemoDbContext _context;

    public DestinationCalendarsServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Destination Calendar
    /// </summary>
    public async Task<DestinationCalendar> CreateDestinationCalendar(
        DestinationCalendarCreateInput createDto
    )
    {
        var destinationCalendar = new DestinationCalendarDbModel
        {
            Integration = createDto.Integration,
            ExternalId = createDto.ExternalId
        };

        if (createDto.Id != null)
        {
            destinationCalendar.Id = createDto.Id.Value;
        }
        if (createDto.Booking != null)
        {
            destinationCalendar.Booking = await _context
                .Bookings.Where(booking => createDto.Booking.Id == booking.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Credential != null)
        {
            destinationCalendar.Credential = await _context
                .Credentials.Where(credential => createDto.Credential.Id == credential.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.EventType != null)
        {
            destinationCalendar.EventType = await _context
                .EventTypes.Where(eventType => createDto.EventType.Id == eventType.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Users != null)
        {
            destinationCalendar.Users = await _context
                .Users.Where(user => createDto.Users.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.DestinationCalendars.Add(destinationCalendar);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<DestinationCalendarDbModel>(destinationCalendar.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Destination Calendar
    /// </summary>
    public async Task DeleteDestinationCalendar(DestinationCalendarWhereUniqueInput uniqueId)
    {
        var destinationCalendar = await _context.DestinationCalendars.FindAsync(uniqueId.Id);
        if (destinationCalendar == null)
        {
            throw new NotFoundException();
        }

        _context.DestinationCalendars.Remove(destinationCalendar);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a Booking record for Destination Calendar
    /// </summary>
    public async Task<Booking> GetBooking(DestinationCalendarWhereUniqueInput uniqueId)
    {
        var destinationCalendar = await _context
            .DestinationCalendars.Where(destinationCalendar =>
                destinationCalendar.Id == uniqueId.Id
            )
            .Include(destinationCalendar => destinationCalendar.Booking)
            .FirstOrDefaultAsync();
        if (destinationCalendar == null)
        {
            throw new NotFoundException();
        }
        return destinationCalendar.Booking.ToDto();
    }

    /// <summary>
    /// Get a Credential record for Destination Calendar
    /// </summary>
    public async Task<Credential> GetCredential(DestinationCalendarWhereUniqueInput uniqueId)
    {
        var destinationCalendar = await _context
            .DestinationCalendars.Where(destinationCalendar =>
                destinationCalendar.Id == uniqueId.Id
            )
            .Include(destinationCalendar => destinationCalendar.Credential)
            .FirstOrDefaultAsync();
        if (destinationCalendar == null)
        {
            throw new NotFoundException();
        }
        return destinationCalendar.Credential.ToDto();
    }

    /// <summary>
    /// Get a Event Type record for Destination Calendar
    /// </summary>
    public async Task<EventType> GetEventType(DestinationCalendarWhereUniqueInput uniqueId)
    {
        var destinationCalendar = await _context
            .DestinationCalendars.Where(destinationCalendar =>
                destinationCalendar.Id == uniqueId.Id
            )
            .Include(destinationCalendar => destinationCalendar.EventType)
            .FirstOrDefaultAsync();
        if (destinationCalendar == null)
        {
            throw new NotFoundException();
        }
        return destinationCalendar.EventType.ToDto();
    }

    /// <summary>
    /// Get a Users record for Destination Calendar
    /// </summary>
    public async Task<User> GetUsers(DestinationCalendarWhereUniqueInput uniqueId)
    {
        var destinationCalendar = await _context
            .DestinationCalendars.Where(destinationCalendar =>
                destinationCalendar.Id == uniqueId.Id
            )
            .Include(destinationCalendar => destinationCalendar.Users)
            .FirstOrDefaultAsync();
        if (destinationCalendar == null)
        {
            throw new NotFoundException();
        }
        return destinationCalendar.Users.ToDto();
    }

    /// <summary>
    /// Meta data about Destination Calendar records
    /// </summary>
    public async Task<MetadataDto> DestinationCalendarsMeta(
        DestinationCalendarFindManyArgs findManyArgs
    )
    {
        var count = await _context.DestinationCalendars.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Find many DestinationCalendars
    /// </summary>
    public async Task<List<DestinationCalendar>> DestinationCalendars(
        DestinationCalendarFindManyArgs findManyArgs
    )
    {
        var destinationCalendars = await _context
            .DestinationCalendars.Include(x => x.Booking)
            .Include(x => x.Credential)
            .Include(x => x.EventType)
            .Include(x => x.Users)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return destinationCalendars.ConvertAll(destinationCalendar => destinationCalendar.ToDto());
    }

    /// <summary>
    /// Get one Destination Calendar
    /// </summary>
    public async Task<DestinationCalendar> DestinationCalendar(
        DestinationCalendarWhereUniqueInput uniqueId
    )
    {
        var destinationCalendars = await this.DestinationCalendars(
            new DestinationCalendarFindManyArgs
            {
                Where = new DestinationCalendarWhereInput { Id = uniqueId.Id }
            }
        );
        var destinationCalendar = destinationCalendars.FirstOrDefault();
        if (destinationCalendar == null)
        {
            throw new NotFoundException();
        }

        return destinationCalendar;
    }

    /// <summary>
    /// Update one Destination Calendar
    /// </summary>
    public async Task UpdateDestinationCalendar(
        DestinationCalendarWhereUniqueInput uniqueId,
        DestinationCalendarUpdateInput updateDto
    )
    {
        var destinationCalendar = updateDto.ToModel(uniqueId);

        _context.Entry(destinationCalendar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.DestinationCalendars.Any(e => e.Id == destinationCalendar.Id))
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
