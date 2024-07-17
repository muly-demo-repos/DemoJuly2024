using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DestinationCalendarsControllerBase : ControllerBase
{
    protected readonly IDestinationCalendarsService _service;

    public DestinationCalendarsControllerBase(IDestinationCalendarsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Destination Calendar
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<DestinationCalendar>> CreateDestinationCalendar(
        DestinationCalendarCreateInput input
    )
    {
        var destinationCalendar = await _service.CreateDestinationCalendar(input);

        return CreatedAtAction(
            nameof(DestinationCalendar),
            new { id = destinationCalendar.Id },
            destinationCalendar
        );
    }

    /// <summary>
    /// Delete one Destination Calendar
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteDestinationCalendar(
        [FromRoute()] DestinationCalendarWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteDestinationCalendar(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Booking record for Destination Calendar
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> GetBooking(
        [FromRoute()] DestinationCalendarWhereUniqueInput uniqueId
    )
    {
        var booking = await _service.GetBooking(uniqueId);
        return Ok(booking);
    }

    /// <summary>
    /// Get a Credential record for Destination Calendar
    /// </summary>
    [HttpGet("{Id}/credentials")]
    public async Task<ActionResult<List<Credential>>> GetCredential(
        [FromRoute()] DestinationCalendarWhereUniqueInput uniqueId
    )
    {
        var credential = await _service.GetCredential(uniqueId);
        return Ok(credential);
    }

    /// <summary>
    /// Get a Event Type record for Destination Calendar
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> GetEventType(
        [FromRoute()] DestinationCalendarWhereUniqueInput uniqueId
    )
    {
        var eventType = await _service.GetEventType(uniqueId);
        return Ok(eventType);
    }

    /// <summary>
    /// Get a Users record for Destination Calendar
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUsers(
        [FromRoute()] DestinationCalendarWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Destination Calendar records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> DestinationCalendarsMeta(
        [FromQuery()] DestinationCalendarFindManyArgs filter
    )
    {
        return Ok(await _service.DestinationCalendarsMeta(filter));
    }

    /// <summary>
    /// Find many DestinationCalendars
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<DestinationCalendar>>> DestinationCalendars(
        [FromQuery()] DestinationCalendarFindManyArgs filter
    )
    {
        return Ok(await _service.DestinationCalendars(filter));
    }

    /// <summary>
    /// Get one Destination Calendar
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<DestinationCalendar>> DestinationCalendar(
        [FromRoute()] DestinationCalendarWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.DestinationCalendar(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Destination Calendar
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateDestinationCalendar(
        [FromRoute()] DestinationCalendarWhereUniqueInput uniqueId,
        [FromQuery()] DestinationCalendarUpdateInput destinationCalendarUpdateDto
    )
    {
        try
        {
            await _service.UpdateDestinationCalendar(uniqueId, destinationCalendarUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
