using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class EventTypeCustomInputsServiceBase : IEventTypeCustomInputsService
{
    protected readonly CactusDemoDbContext _context;

    public EventTypeCustomInputsServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Event Type Custom Input
    /// </summary>
    public async Task<EventTypeCustomInput> CreateEventTypeCustomInput(
        EventTypeCustomInputCreateInput createDto
    )
    {
        var eventTypeCustomInput = new EventTypeCustomInputDbModel
        {
            Label = createDto.Label,
            Type = createDto.Type,
            Required = createDto.Required,
            Placeholder = createDto.Placeholder
        };

        if (createDto.Id != null)
        {
            eventTypeCustomInput.Id = createDto.Id.Value;
        }
        if (createDto.EventType != null)
        {
            eventTypeCustomInput.EventType = await _context
                .EventTypes.Where(eventType => createDto.EventType.Id == eventType.Id)
                .FirstOrDefaultAsync();
        }

        _context.EventTypeCustomInputs.Add(eventTypeCustomInput);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<EventTypeCustomInputDbModel>(eventTypeCustomInput.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Event Type Custom Input
    /// </summary>
    public async Task DeleteEventTypeCustomInput(EventTypeCustomInputWhereUniqueInput uniqueId)
    {
        var eventTypeCustomInput = await _context.EventTypeCustomInputs.FindAsync(uniqueId.Id);
        if (eventTypeCustomInput == null)
        {
            throw new NotFoundException();
        }

        _context.EventTypeCustomInputs.Remove(eventTypeCustomInput);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a Event Type record for Event Type Custom Input
    /// </summary>
    public async Task<EventType> GetEventType(EventTypeCustomInputWhereUniqueInput uniqueId)
    {
        var eventTypeCustomInput = await _context
            .EventTypeCustomInputs.Where(eventTypeCustomInput =>
                eventTypeCustomInput.Id == uniqueId.Id
            )
            .Include(eventTypeCustomInput => eventTypeCustomInput.EventType)
            .FirstOrDefaultAsync();
        if (eventTypeCustomInput == null)
        {
            throw new NotFoundException();
        }
        return eventTypeCustomInput.EventType.ToDto();
    }

    /// <summary>
    /// Meta data about Event Type Custom Input records
    /// </summary>
    public async Task<MetadataDto> EventTypeCustomInputsMeta(
        EventTypeCustomInputFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .EventTypeCustomInputs.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Find many EventTypeCustomInputs
    /// </summary>
    public async Task<List<EventTypeCustomInput>> EventTypeCustomInputs(
        EventTypeCustomInputFindManyArgs findManyArgs
    )
    {
        var eventTypeCustomInputs = await _context
            .EventTypeCustomInputs.Include(x => x.EventType)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return eventTypeCustomInputs.ConvertAll(eventTypeCustomInput =>
            eventTypeCustomInput.ToDto()
        );
    }

    /// <summary>
    /// Get one Event Type Custom Input
    /// </summary>
    public async Task<EventTypeCustomInput> EventTypeCustomInput(
        EventTypeCustomInputWhereUniqueInput uniqueId
    )
    {
        var eventTypeCustomInputs = await this.EventTypeCustomInputs(
            new EventTypeCustomInputFindManyArgs
            {
                Where = new EventTypeCustomInputWhereInput { Id = uniqueId.Id }
            }
        );
        var eventTypeCustomInput = eventTypeCustomInputs.FirstOrDefault();
        if (eventTypeCustomInput == null)
        {
            throw new NotFoundException();
        }

        return eventTypeCustomInput;
    }

    /// <summary>
    /// Update one Event Type Custom Input
    /// </summary>
    public async Task UpdateEventTypeCustomInput(
        EventTypeCustomInputWhereUniqueInput uniqueId,
        EventTypeCustomInputUpdateInput updateDto
    )
    {
        var eventTypeCustomInput = updateDto.ToModel(uniqueId);

        _context.Entry(eventTypeCustomInput).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.EventTypeCustomInputs.Any(e => e.Id == eventTypeCustomInput.Id))
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
