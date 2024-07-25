using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AvailabilitiesControllerBase : ControllerBase
{
    protected readonly IAvailabilitiesService _service;

    public AvailabilitiesControllerBase(IAvailabilitiesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Meta data about Availability records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AvailabilitiesMeta(
        [FromQuery()] AvailabilityFindManyArgs filter
    )
    {
        return Ok(await _service.AvailabilitiesMeta(filter));
    }

    /// <summary>
    /// Get a Event Type record for Availability
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> GetEventType(
        [FromRoute()] AvailabilityWhereUniqueInput uniqueId
    )
    {
        var eventType = await _service.GetEventType(uniqueId);
        return Ok(eventType);
    }

    /// <summary>
    /// Get a Schedule record for Availability
    /// </summary>
    [HttpGet("{Id}/schedules")]
    public async Task<ActionResult<List<Schedule>>> GetSchedule(
        [FromRoute()] AvailabilityWhereUniqueInput uniqueId
    )
    {
        var schedule = await _service.GetSchedule(uniqueId);
        return Ok(schedule);
    }

    /// <summary>
    /// Get a Users record for Availability
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUsers(
        [FromRoute()] AvailabilityWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Create one Availability
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Availability>> CreateAvailability(AvailabilityCreateInput input)
    {
        var availability = await _service.CreateAvailability(input);

        return CreatedAtAction(nameof(Availability), new { id = availability.Id }, availability);
    }

    /// <summary>
    /// Delete one Availability
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAvailability(
        [FromRoute()] AvailabilityWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAvailability(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Availabilities
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Availability>>> Availabilities(
        [FromQuery()] AvailabilityFindManyArgs filter
    )
    {
        return Ok(await _service.Availabilities(filter));
    }

    /// <summary>
    /// Get one Availability
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Availability>> Availability(
        [FromRoute()] AvailabilityWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Availability(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Availability
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAvailability(
        [FromRoute()] AvailabilityWhereUniqueInput uniqueId,
        [FromQuery()] AvailabilityUpdateInput availabilityUpdateDto
    )
    {
        try
        {
            await _service.UpdateAvailability(uniqueId, availabilityUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
