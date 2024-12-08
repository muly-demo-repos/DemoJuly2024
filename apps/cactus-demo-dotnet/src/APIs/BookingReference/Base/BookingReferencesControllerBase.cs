using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BookingReferencesControllerBase : ControllerBase
{
    protected readonly IBookingReferencesService _service;

    public BookingReferencesControllerBase(IBookingReferencesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get a Booking record for Booking Reference
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> GetBooking(
        [FromRoute()] BookingReferenceWhereUniqueInput uniqueId
    )
    {
        var booking = await _service.GetBooking(uniqueId);
        return Ok(booking);
    }

    /// <summary>
    /// Meta data about Booking Reference records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BookingReferencesMeta(
        [FromQuery()] BookingReferenceFindManyArgs filter
    )
    {
        return Ok(await _service.BookingReferencesMeta(filter));
    }

    /// <summary>
    /// Create one Booking Reference
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<BookingReference>> CreateBookingReference(
        BookingReferenceCreateInput input
    )
    {
        var bookingReference = await _service.CreateBookingReference(input);

        return CreatedAtAction(
            nameof(BookingReference),
            new { id = bookingReference.Id },
            bookingReference
        );
    }

    /// <summary>
    /// Delete one Booking Reference
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBookingReference(
        [FromRoute()] BookingReferenceWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteBookingReference(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many BookingReferences
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<BookingReference>>> BookingReferences(
        [FromQuery()] BookingReferenceFindManyArgs filter
    )
    {
        return Ok(await _service.BookingReferences(filter));
    }

    /// <summary>
    /// Get one Booking Reference
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<BookingReference>> BookingReference(
        [FromRoute()] BookingReferenceWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.BookingReference(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Booking Reference
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBookingReference(
        [FromRoute()] BookingReferenceWhereUniqueInput uniqueId,
        [FromQuery()] BookingReferenceUpdateInput bookingReferenceUpdateDto
    )
    {
        try
        {
            await _service.UpdateBookingReference(uniqueId, bookingReferenceUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
