using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EventTypeCustomInputsControllerBase : ControllerBase
{
    protected readonly IEventTypeCustomInputsService _service;

    public EventTypeCustomInputsControllerBase(IEventTypeCustomInputsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Event Type Custom Input
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<EventTypeCustomInput>> CreateEventTypeCustomInput(
        EventTypeCustomInputCreateInput input
    )
    {
        var eventTypeCustomInput = await _service.CreateEventTypeCustomInput(input);

        return CreatedAtAction(
            nameof(EventTypeCustomInput),
            new { id = eventTypeCustomInput.Id },
            eventTypeCustomInput
        );
    }

    /// <summary>
    /// Delete one Event Type Custom Input
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteEventTypeCustomInput(
        [FromRoute()] EventTypeCustomInputWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteEventTypeCustomInput(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Event Type record for Event Type Custom Input
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> GetEventType(
        [FromRoute()] EventTypeCustomInputWhereUniqueInput uniqueId
    )
    {
        var eventType = await _service.GetEventType(uniqueId);
        return Ok(eventType);
    }

    /// <summary>
    /// Meta data about Event Type Custom Input records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EventTypeCustomInputsMeta(
        [FromQuery()] EventTypeCustomInputFindManyArgs filter
    )
    {
        return Ok(await _service.EventTypeCustomInputsMeta(filter));
    }

    /// <summary>
    /// Find many EventTypeCustomInputs
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<EventTypeCustomInput>>> EventTypeCustomInputs(
        [FromQuery()] EventTypeCustomInputFindManyArgs filter
    )
    {
        return Ok(await _service.EventTypeCustomInputs(filter));
    }

    /// <summary>
    /// Get one Event Type Custom Input
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<EventTypeCustomInput>> EventTypeCustomInput(
        [FromRoute()] EventTypeCustomInputWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.EventTypeCustomInput(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Event Type Custom Input
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateEventTypeCustomInput(
        [FromRoute()] EventTypeCustomInputWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeCustomInputUpdateInput eventTypeCustomInputUpdateDto
    )
    {
        try
        {
            await _service.UpdateEventTypeCustomInput(uniqueId, eventTypeCustomInputUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
