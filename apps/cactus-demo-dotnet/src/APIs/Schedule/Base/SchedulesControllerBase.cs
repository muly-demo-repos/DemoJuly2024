using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SchedulesControllerBase : ControllerBase
{
    protected readonly ISchedulesService _service;

    public SchedulesControllerBase(ISchedulesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Schedule
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Schedule>> CreateSchedule(ScheduleCreateInput input)
    {
        var schedule = await _service.CreateSchedule(input);

        return CreatedAtAction(nameof(Schedule), new { id = schedule.Id }, schedule);
    }

    /// <summary>
    /// Delete one Schedule
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSchedule([FromRoute()] ScheduleWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteSchedule(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Schedules
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Schedule>>> Schedules(
        [FromQuery()] ScheduleFindManyArgs filter
    )
    {
        return Ok(await _service.Schedules(filter));
    }

    /// <summary>
    /// Get one Schedule
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Schedule>> Schedule(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Schedule(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Connect multiple Availability records to Schedule
    /// </summary>
    [HttpPost("{Id}/availabilities")]
    public async Task<ActionResult> ConnectAvailability(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId,
        [FromQuery()] AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        try
        {
            await _service.ConnectAvailability(uniqueId, availabilitiesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Event Type records to Schedule
    /// </summary>
    [HttpPost("{Id}/eventTypes")]
    public async Task<ActionResult> ConnectEventType(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.ConnectEventType(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Availability records from Schedule
    /// </summary>
    [HttpDelete("{Id}/availabilities")]
    public async Task<ActionResult> DisconnectAvailability(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId,
        [FromBody()] AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        try
        {
            await _service.DisconnectAvailability(uniqueId, availabilitiesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Event Type records from Schedule
    /// </summary>
    [HttpDelete("{Id}/eventTypes")]
    public async Task<ActionResult> DisconnectEventType(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId,
        [FromBody()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.DisconnectEventType(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Availability records for Schedule
    /// </summary>
    [HttpGet("{Id}/availabilities")]
    public async Task<ActionResult<List<Availability>>> FindAvailability(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId,
        [FromQuery()] AvailabilityFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAvailability(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Event Type records for Schedule
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> FindEventType(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindEventType(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a User record for Schedule
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Schedule records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SchedulesMeta(
        [FromQuery()] ScheduleFindManyArgs filter
    )
    {
        return Ok(await _service.SchedulesMeta(filter));
    }

    /// <summary>
    /// Update multiple Availability records for Schedule
    /// </summary>
    [HttpPatch("{Id}/availabilities")]
    public async Task<ActionResult> UpdateAvailability(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId,
        [FromBody()] AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        try
        {
            await _service.UpdateAvailability(uniqueId, availabilitiesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Event Type records for Schedule
    /// </summary>
    [HttpPatch("{Id}/eventTypes")]
    public async Task<ActionResult> UpdateEventType(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId,
        [FromBody()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.UpdateEventType(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update one Schedule
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSchedule(
        [FromRoute()] ScheduleWhereUniqueInput uniqueId,
        [FromQuery()] ScheduleUpdateInput scheduleUpdateDto
    )
    {
        try
        {
            await _service.UpdateSchedule(uniqueId, scheduleUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
