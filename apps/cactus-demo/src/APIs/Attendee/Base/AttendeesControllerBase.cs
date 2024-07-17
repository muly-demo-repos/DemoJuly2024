using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AttendeesControllerBase : ControllerBase
{
    protected readonly IAttendeesService _service;

    public AttendeesControllerBase(IAttendeesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get a Booking record for Attendee
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> GetBooking(
        [FromRoute()] AttendeeWhereUniqueInput uniqueId
    )
    {
        var booking = await _service.GetBooking(uniqueId);
        return Ok(booking);
    }

    /// <summary>
    /// Meta data about Attendee records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AttendeesMeta(
        [FromQuery()] AttendeeFindManyArgs filter
    )
    {
        return Ok(await _service.AttendeesMeta(filter));
    }

    /// <summary>
    /// Create one Attendee
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Attendee>> CreateAttendee(AttendeeCreateInput input)
    {
        var attendee = await _service.CreateAttendee(input);

        return CreatedAtAction(nameof(Attendee), new { id = attendee.Id }, attendee);
    }

    /// <summary>
    /// Delete one Attendee
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAttendee([FromRoute()] AttendeeWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAttendee(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Attendees
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Attendee>>> Attendees(
        [FromQuery()] AttendeeFindManyArgs filter
    )
    {
        return Ok(await _service.Attendees(filter));
    }

    /// <summary>
    /// Get one Attendee
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Attendee>> Attendee(
        [FromRoute()] AttendeeWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Attendee(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Attendee
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAttendee(
        [FromRoute()] AttendeeWhereUniqueInput uniqueId,
        [FromQuery()] AttendeeUpdateInput attendeeUpdateDto
    )
    {
        try
        {
            await _service.UpdateAttendee(uniqueId, attendeeUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
