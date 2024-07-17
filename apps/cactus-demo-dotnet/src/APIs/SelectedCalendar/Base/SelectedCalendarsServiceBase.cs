using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class SelectedCalendarsServiceBase : ISelectedCalendarsService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public SelectedCalendarsServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Selected Calendar
    /// </summary>
    public async Task<SelectedCalendar> CreateSelectedCalendar(
        SelectedCalendarCreateInput createDto
    )
    {
        var selectedCalendar = new SelectedCalendarDbModel
        {
            Integration = createDto.Integration,
            ExternalId = createDto.ExternalId
        };

        if (createDto.Id != null)
        {
            selectedCalendar.Id = createDto.Id.Value;
        }
        if (createDto.User != null)
        {
            selectedCalendar.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.SelectedCalendars.Add(selectedCalendar);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SelectedCalendarDbModel>(selectedCalendar.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Selected Calendar
    /// </summary>
    public async Task DeleteSelectedCalendar(SelectedCalendarWhereUniqueInput uniqueId)
    {
        var selectedCalendar = await _context.SelectedCalendars.FindAsync(uniqueId.Id);
        if (selectedCalendar == null)
        {
            throw new NotFoundException();
        }

        _context.SelectedCalendars.Remove(selectedCalendar);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many SelectedCalendars
    /// </summary>
    public async Task<List<SelectedCalendar>> SelectedCalendars(
        SelectedCalendarFindManyArgs findManyArgs
    )
    {
        var selectedCalendars = await _context
            .SelectedCalendars.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return selectedCalendars.ConvertAll(selectedCalendar => selectedCalendar.ToDto());
    }

    /// <summary>
    /// Get one Selected Calendar
    /// </summary>
    public async Task<SelectedCalendar> SelectedCalendar(SelectedCalendarWhereUniqueInput uniqueId)
    {
        var selectedCalendars = await this.SelectedCalendars(
            new SelectedCalendarFindManyArgs
            {
                Where = new SelectedCalendarWhereInput { Id = uniqueId.Id }
            }
        );
        var selectedCalendar = selectedCalendars.FirstOrDefault();
        if (selectedCalendar == null)
        {
            throw new NotFoundException();
        }

        return selectedCalendar;
    }

    /// <summary>
    /// Get a User record for Selected Calendar
    /// </summary>
    public async Task<User> GetUser(SelectedCalendarWhereUniqueInput uniqueId)
    {
        var selectedCalendar = await _context
            .SelectedCalendars.Where(selectedCalendar => selectedCalendar.Id == uniqueId.Id)
            .Include(selectedCalendar => selectedCalendar.User)
            .FirstOrDefaultAsync();
        if (selectedCalendar == null)
        {
            throw new NotFoundException();
        }
        return selectedCalendar.User.ToDto();
    }

    /// <summary>
    /// Meta data about Selected Calendar records
    /// </summary>
    public async Task<MetadataDto> SelectedCalendarsMeta(SelectedCalendarFindManyArgs findManyArgs)
    {
        var count = await _context.SelectedCalendars.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Selected Calendar
    /// </summary>
    public async Task UpdateSelectedCalendar(
        SelectedCalendarWhereUniqueInput uniqueId,
        SelectedCalendarUpdateInput updateDto
    )
    {
        var selectedCalendar = updateDto.ToModel(uniqueId);

        _context.Entry(selectedCalendar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.SelectedCalendars.Any(e => e.Id == selectedCalendar.Id))
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
