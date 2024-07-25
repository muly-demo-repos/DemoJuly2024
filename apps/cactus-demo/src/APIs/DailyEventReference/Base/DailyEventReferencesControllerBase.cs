using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DailyEventReferencesControllerBase : ControllerBase
{
    protected readonly IDailyEventReferencesService _service;

    public DailyEventReferencesControllerBase(IDailyEventReferencesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Daily Event Reference
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<DailyEventReference>> CreateDailyEventReference(
        DailyEventReferenceCreateInput input
    )
    {
        var dailyEventReference = await _service.CreateDailyEventReference(input);

        return CreatedAtAction(
            nameof(DailyEventReference),
            new { id = dailyEventReference.Id },
            dailyEventReference
        );
    }

    /// <summary>
    /// Get a Booking record for Daily Event Reference
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> GetBooking(
        [FromRoute()] DailyEventReferenceWhereUniqueInput uniqueId
    )
    {
        var booking = await _service.GetBooking(uniqueId);
        return Ok(booking);
    }

    /// <summary>
    /// Meta data about Daily Event Reference records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> DailyEventReferencesMeta(
        [FromQuery()] DailyEventReferenceFindManyArgs filter
    )
    {
        return Ok(await _service.DailyEventReferencesMeta(filter));
    }

    /// <summary>
    /// Delete one Daily Event Reference
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteDailyEventReference(
        [FromRoute()] DailyEventReferenceWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteDailyEventReference(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many DailyEventReferences
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<DailyEventReference>>> DailyEventReferences(
        [FromQuery()] DailyEventReferenceFindManyArgs filter
    )
    {
        return Ok(await _service.DailyEventReferences(filter));
    }

    /// <summary>
    /// Get one Daily Event Reference
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<DailyEventReference>> DailyEventReference(
        [FromRoute()] DailyEventReferenceWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.DailyEventReference(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Daily Event Reference
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateDailyEventReference(
        [FromRoute()] DailyEventReferenceWhereUniqueInput uniqueId,
        [FromQuery()] DailyEventReferenceUpdateInput dailyEventReferenceUpdateDto
    )
    {
        try
        {
            await _service.UpdateDailyEventReference(uniqueId, dailyEventReferenceUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
