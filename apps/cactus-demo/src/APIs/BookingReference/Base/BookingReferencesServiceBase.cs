using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class BookingReferencesServiceBase : IBookingReferencesService
{
    protected readonly CactusDemoDbContext _context;

    public BookingReferencesServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get a Booking record for Booking Reference
    /// </summary>
    public async Task<Booking> GetBooking(BookingReferenceWhereUniqueInput uniqueId)
    {
        var bookingReference = await _context
            .BookingReferences.Where(bookingReference => bookingReference.Id == uniqueId.Id)
            .Include(bookingReference => bookingReference.Booking)
            .FirstOrDefaultAsync();
        if (bookingReference == null)
        {
            throw new NotFoundException();
        }
        return bookingReference.Booking.ToDto();
    }

    /// <summary>
    /// Meta data about Booking Reference records
    /// </summary>
    public async Task<MetadataDto> BookingReferencesMeta(BookingReferenceFindManyArgs findManyArgs)
    {
        var count = await _context.BookingReferences.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Create one Booking Reference
    /// </summary>
    public async Task<BookingReference> CreateBookingReference(
        BookingReferenceCreateInput createDto
    )
    {
        var bookingReference = new BookingReferenceDbModel
        {
            TypeField = createDto.TypeField,
            Uid = createDto.Uid,
            MeetingId = createDto.MeetingId,
            MeetingPassword = createDto.MeetingPassword,
            MeetingUrl = createDto.MeetingUrl,
            ExternalCalendarId = createDto.ExternalCalendarId,
            Deleted = createDto.Deleted
        };

        if (createDto.Id != null)
        {
            bookingReference.Id = createDto.Id.Value;
        }
        if (createDto.Booking != null)
        {
            bookingReference.Booking = await _context
                .Bookings.Where(booking => createDto.Booking.Id == booking.Id)
                .FirstOrDefaultAsync();
        }

        _context.BookingReferences.Add(bookingReference);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BookingReferenceDbModel>(bookingReference.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Booking Reference
    /// </summary>
    public async Task DeleteBookingReference(BookingReferenceWhereUniqueInput uniqueId)
    {
        var bookingReference = await _context.BookingReferences.FindAsync(uniqueId.Id);
        if (bookingReference == null)
        {
            throw new NotFoundException();
        }

        _context.BookingReferences.Remove(bookingReference);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many BookingReferences
    /// </summary>
    public async Task<List<BookingReference>> BookingReferences(
        BookingReferenceFindManyArgs findManyArgs
    )
    {
        var bookingReferences = await _context
            .BookingReferences.Include(x => x.Booking)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return bookingReferences.ConvertAll(bookingReference => bookingReference.ToDto());
    }

    /// <summary>
    /// Get one Booking Reference
    /// </summary>
    public async Task<BookingReference> BookingReference(BookingReferenceWhereUniqueInput uniqueId)
    {
        var bookingReferences = await this.BookingReferences(
            new BookingReferenceFindManyArgs
            {
                Where = new BookingReferenceWhereInput { Id = uniqueId.Id }
            }
        );
        var bookingReference = bookingReferences.FirstOrDefault();
        if (bookingReference == null)
        {
            throw new NotFoundException();
        }

        return bookingReference;
    }

    /// <summary>
    /// Update one Booking Reference
    /// </summary>
    public async Task UpdateBookingReference(
        BookingReferenceWhereUniqueInput uniqueId,
        BookingReferenceUpdateInput updateDto
    )
    {
        var bookingReference = updateDto.ToModel(uniqueId);

        _context.Entry(bookingReference).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.BookingReferences.Any(e => e.Id == bookingReference.Id))
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
