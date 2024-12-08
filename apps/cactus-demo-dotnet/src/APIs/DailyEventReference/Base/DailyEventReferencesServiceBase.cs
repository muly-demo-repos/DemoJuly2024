using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class DailyEventReferencesServiceBase : IDailyEventReferencesService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public DailyEventReferencesServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Daily Event Reference
    /// </summary>
    public async Task<DailyEventReference> CreateDailyEventReference(
        DailyEventReferenceCreateInput createDto
    )
    {
        var dailyEventReference = new DailyEventReferenceDbModel
        {
            Dailyurl = createDto.Dailyurl,
            Dailytoken = createDto.Dailytoken
        };

        if (createDto.Id != null)
        {
            dailyEventReference.Id = createDto.Id.Value;
        }
        if (createDto.Booking != null)
        {
            dailyEventReference.Booking = await _context
                .Bookings.Where(booking => createDto.Booking.Id == booking.Id)
                .FirstOrDefaultAsync();
        }

        _context.DailyEventReferences.Add(dailyEventReference);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<DailyEventReferenceDbModel>(dailyEventReference.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Get a Booking record for Daily Event Reference
    /// </summary>
    public async Task<Booking> GetBooking(DailyEventReferenceWhereUniqueInput uniqueId)
    {
        var dailyEventReference = await _context
            .DailyEventReferences.Where(dailyEventReference =>
                dailyEventReference.Id == uniqueId.Id
            )
            .Include(dailyEventReference => dailyEventReference.Booking)
            .FirstOrDefaultAsync();
        if (dailyEventReference == null)
        {
            throw new NotFoundException();
        }
        return dailyEventReference.Booking.ToDto();
    }

    /// <summary>
    /// Meta data about Daily Event Reference records
    /// </summary>
    public async Task<MetadataDto> DailyEventReferencesMeta(
        DailyEventReferenceFindManyArgs findManyArgs
    )
    {
        var count = await _context.DailyEventReferences.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Delete one Daily Event Reference
    /// </summary>
    public async Task DeleteDailyEventReference(DailyEventReferenceWhereUniqueInput uniqueId)
    {
        var dailyEventReference = await _context.DailyEventReferences.FindAsync(uniqueId.Id);
        if (dailyEventReference == null)
        {
            throw new NotFoundException();
        }

        _context.DailyEventReferences.Remove(dailyEventReference);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many DailyEventReferences
    /// </summary>
    public async Task<List<DailyEventReference>> DailyEventReferences(
        DailyEventReferenceFindManyArgs findManyArgs
    )
    {
        var dailyEventReferences = await _context
            .DailyEventReferences.Include(x => x.Booking)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return dailyEventReferences.ConvertAll(dailyEventReference => dailyEventReference.ToDto());
    }

    /// <summary>
    /// Get one Daily Event Reference
    /// </summary>
    public async Task<DailyEventReference> DailyEventReference(
        DailyEventReferenceWhereUniqueInput uniqueId
    )
    {
        var dailyEventReferences = await this.DailyEventReferences(
            new DailyEventReferenceFindManyArgs
            {
                Where = new DailyEventReferenceWhereInput { Id = uniqueId.Id }
            }
        );
        var dailyEventReference = dailyEventReferences.FirstOrDefault();
        if (dailyEventReference == null)
        {
            throw new NotFoundException();
        }

        return dailyEventReference;
    }

    /// <summary>
    /// Update one Daily Event Reference
    /// </summary>
    public async Task UpdateDailyEventReference(
        DailyEventReferenceWhereUniqueInput uniqueId,
        DailyEventReferenceUpdateInput updateDto
    )
    {
        var dailyEventReference = updateDto.ToModel(uniqueId);

        _context.Entry(dailyEventReference).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.DailyEventReferences.Any(e => e.Id == dailyEventReference.Id))
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
