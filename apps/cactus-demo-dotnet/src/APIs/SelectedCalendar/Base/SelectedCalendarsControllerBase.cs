using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SelectedCalendarsControllerBase : ControllerBase
{
    protected readonly ISelectedCalendarsService _service;

    public SelectedCalendarsControllerBase(ISelectedCalendarsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Selected Calendar
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<SelectedCalendar>> CreateSelectedCalendar(
        SelectedCalendarCreateInput input
    )
    {
        var selectedCalendar = await _service.CreateSelectedCalendar(input);

        return CreatedAtAction(
            nameof(SelectedCalendar),
            new { id = selectedCalendar.Id },
            selectedCalendar
        );
    }

    /// <summary>
    /// Delete one Selected Calendar
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSelectedCalendar(
        [FromRoute()] SelectedCalendarWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteSelectedCalendar(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many SelectedCalendars
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<SelectedCalendar>>> SelectedCalendars(
        [FromQuery()] SelectedCalendarFindManyArgs filter
    )
    {
        return Ok(await _service.SelectedCalendars(filter));
    }

    /// <summary>
    /// Get one Selected Calendar
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<SelectedCalendar>> SelectedCalendar(
        [FromRoute()] SelectedCalendarWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.SelectedCalendar(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a User record for Selected Calendar
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] SelectedCalendarWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Selected Calendar records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SelectedCalendarsMeta(
        [FromQuery()] SelectedCalendarFindManyArgs filter
    )
    {
        return Ok(await _service.SelectedCalendarsMeta(filter));
    }

    /// <summary>
    /// Update one Selected Calendar
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSelectedCalendar(
        [FromRoute()] SelectedCalendarWhereUniqueInput uniqueId,
        [FromQuery()] SelectedCalendarUpdateInput selectedCalendarUpdateDto
    )
    {
        try
        {
            await _service.UpdateSelectedCalendar(uniqueId, selectedCalendarUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
