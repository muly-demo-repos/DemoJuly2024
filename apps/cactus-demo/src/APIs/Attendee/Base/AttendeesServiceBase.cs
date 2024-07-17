using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class AttendeesServiceBase : IAttendeesService
{
    protected readonly CactusDemoDbContext _context;

    public AttendeesServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get a Booking record for Attendee
    /// </summary>
    public async Task<Booking> GetBooking(AttendeeWhereUniqueInput uniqueId)
    {
        var attendee = await _context
            .Attendees.Where(attendee => attendee.Id == uniqueId.Id)
            .Include(attendee => attendee.Booking)
            .FirstOrDefaultAsync();
        if (attendee == null)
        {
            throw new NotFoundException();
        }
        return attendee.Booking.ToDto();
    }

    /// <summary>
    /// Meta data about Attendee records
    /// </summary>
    public async Task<MetadataDto> AttendeesMeta(AttendeeFindManyArgs findManyArgs)
    {
        var count = await _context.Attendees.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Create one Attendee
    /// </summary>
    public async Task<Attendee> CreateAttendee(AttendeeCreateInput createDto)
    {
        var attendee = new AttendeeDbModel
        {
            Email = createDto.Email,
            Name = createDto.Name,
            TimeZone = createDto.TimeZone,
            Locale = createDto.Locale
        };

        if (createDto.Id != null)
        {
            attendee.Id = createDto.Id.Value;
        }
        if (createDto.Booking != null)
        {
            attendee.Booking = await _context
                .Bookings.Where(booking => createDto.Booking.Id == booking.Id)
                .FirstOrDefaultAsync();
        }

        _context.Attendees.Add(attendee);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AttendeeDbModel>(attendee.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Attendee
    /// </summary>
    public async Task DeleteAttendee(AttendeeWhereUniqueInput uniqueId)
    {
        var attendee = await _context.Attendees.FindAsync(uniqueId.Id);
        if (attendee == null)
        {
            throw new NotFoundException();
        }

        _context.Attendees.Remove(attendee);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Attendees
    /// </summary>
    public async Task<List<Attendee>> Attendees(AttendeeFindManyArgs findManyArgs)
    {
        var attendees = await _context
            .Attendees.Include(x => x.Booking)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return attendees.ConvertAll(attendee => attendee.ToDto());
    }

    /// <summary>
    /// Get one Attendee
    /// </summary>
    public async Task<Attendee> Attendee(AttendeeWhereUniqueInput uniqueId)
    {
        var attendees = await this.Attendees(
            new AttendeeFindManyArgs { Where = new AttendeeWhereInput { Id = uniqueId.Id } }
        );
        var attendee = attendees.FirstOrDefault();
        if (attendee == null)
        {
            throw new NotFoundException();
        }

        return attendee;
    }

    /// <summary>
    /// Update one Attendee
    /// </summary>
    public async Task UpdateAttendee(
        AttendeeWhereUniqueInput uniqueId,
        AttendeeUpdateInput updateDto
    )
    {
        var attendee = updateDto.ToModel(uniqueId);

        _context.Entry(attendee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Attendees.Any(e => e.Id == attendee.Id))
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
