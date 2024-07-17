using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IEventTypeCustomInputsService
{
    /// <summary>
    /// Create one Event Type Custom Input
    /// </summary>
    public Task<EventTypeCustomInput> CreateEventTypeCustomInput(
        EventTypeCustomInputCreateInput eventtypecustominput
    );

    /// <summary>
    /// Delete one Event Type Custom Input
    /// </summary>
    public Task DeleteEventTypeCustomInput(EventTypeCustomInputWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Event Type record for Event Type Custom Input
    /// </summary>
    public Task<EventType> GetEventType(EventTypeCustomInputWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Event Type Custom Input records
    /// </summary>
    public Task<MetadataDto> EventTypeCustomInputsMeta(
        EventTypeCustomInputFindManyArgs findManyArgs
    );

    /// <summary>
    /// Find many EventTypeCustomInputs
    /// </summary>
    public Task<List<EventTypeCustomInput>> EventTypeCustomInputs(
        EventTypeCustomInputFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one Event Type Custom Input
    /// </summary>
    public Task<EventTypeCustomInput> EventTypeCustomInput(
        EventTypeCustomInputWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one Event Type Custom Input
    /// </summary>
    public Task UpdateEventTypeCustomInput(
        EventTypeCustomInputWhereUniqueInput uniqueId,
        EventTypeCustomInputUpdateInput updateDto
    );
}
