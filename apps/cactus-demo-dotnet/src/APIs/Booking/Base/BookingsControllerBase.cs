using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BookingsControllerBase : ControllerBase
{
    protected readonly IBookingsService _service;

    public BookingsControllerBase(IBookingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Connect multiple Attendees records to Booking
    /// </summary>
    [HttpPost("{Id}/attendees")]
    public async Task<ActionResult> ConnectAttendees(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] AttendeeWhereUniqueInput[] attendeesId
    )
    {
        try
        {
            await _service.ConnectAttendees(uniqueId, attendeesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Payment records to Booking
    /// </summary>
    [HttpPost("{Id}/payments")]
    public async Task<ActionResult> ConnectPayment(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.ConnectPayment(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple References records to Booking
    /// </summary>
    [HttpPost("{Id}/bookingReferences")]
    public async Task<ActionResult> ConnectReferences(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        try
        {
            await _service.ConnectReferences(uniqueId, bookingReferencesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Workflow Reminders records to Booking
    /// </summary>
    [HttpPost("{Id}/workflowReminders")]
    public async Task<ActionResult> ConnectWorkflowReminders(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        try
        {
            await _service.ConnectWorkflowReminders(uniqueId, workflowRemindersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Attendees records from Booking
    /// </summary>
    [HttpDelete("{Id}/attendees")]
    public async Task<ActionResult> DisconnectAttendees(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] AttendeeWhereUniqueInput[] attendeesId
    )
    {
        try
        {
            await _service.DisconnectAttendees(uniqueId, attendeesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Payment records from Booking
    /// </summary>
    [HttpDelete("{Id}/payments")]
    public async Task<ActionResult> DisconnectPayment(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.DisconnectPayment(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple References records from Booking
    /// </summary>
    [HttpDelete("{Id}/bookingReferences")]
    public async Task<ActionResult> DisconnectReferences(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        try
        {
            await _service.DisconnectReferences(uniqueId, bookingReferencesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Workflow Reminders records from Booking
    /// </summary>
    [HttpDelete("{Id}/workflowReminders")]
    public async Task<ActionResult> DisconnectWorkflowReminders(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        try
        {
            await _service.DisconnectWorkflowReminders(uniqueId, workflowRemindersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Attendees records for Booking
    /// </summary>
    [HttpGet("{Id}/attendees")]
    public async Task<ActionResult<List<Attendee>>> FindAttendees(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] AttendeeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAttendees(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Payment records for Booking
    /// </summary>
    [HttpGet("{Id}/payments")]
    public async Task<ActionResult<List<Payment>>> FindPayment(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] PaymentFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPayment(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple References records for Booking
    /// </summary>
    [HttpGet("{Id}/bookingReferences")]
    public async Task<ActionResult<List<BookingReference>>> FindReferences(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] BookingReferenceFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindReferences(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Workflow Reminders records for Booking
    /// </summary>
    [HttpGet("{Id}/workflowReminders")]
    public async Task<ActionResult<List<WorkflowReminder>>> FindWorkflowReminders(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowReminderFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWorkflowReminders(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Daily Ref record for Booking
    /// </summary>
    [HttpGet("{Id}/dailyEventReferences")]
    public async Task<ActionResult<List<DailyEventReference>>> GetDailyRef(
        [FromRoute()] BookingWhereUniqueInput uniqueId
    )
    {
        var dailyEventReference = await _service.GetDailyEventReference(uniqueId);
        return Ok(dailyEventReference);
    }

    /// <summary>
    /// Get a Destination Calendar record for Booking
    /// </summary>
    [HttpGet("{Id}/destinationCalendars")]
    public async Task<ActionResult<List<DestinationCalendar>>> GetDestinationCalendar(
        [FromRoute()] BookingWhereUniqueInput uniqueId
    )
    {
        var destinationCalendar = await _service.GetDestinationCalendar(uniqueId);
        return Ok(destinationCalendar);
    }

    /// <summary>
    /// Get a Event Type record for Booking
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> GetEventType(
        [FromRoute()] BookingWhereUniqueInput uniqueId
    )
    {
        var eventType = await _service.GetEventType(uniqueId);
        return Ok(eventType);
    }

    /// <summary>
    /// Get a User record for Booking
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] BookingWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Booking records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BookingsMeta(
        [FromQuery()] BookingFindManyArgs filter
    )
    {
        return Ok(await _service.BookingsMeta(filter));
    }

    /// <summary>
    /// Update multiple Attendees records for Booking
    /// </summary>
    [HttpPatch("{Id}/attendees")]
    public async Task<ActionResult> UpdateAttendees(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] AttendeeWhereUniqueInput[] attendeesId
    )
    {
        try
        {
            await _service.UpdateAttendees(uniqueId, attendeesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Payment records for Booking
    /// </summary>
    [HttpPatch("{Id}/payments")]
    public async Task<ActionResult> UpdatePayment(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.UpdatePayment(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple References records for Booking
    /// </summary>
    [HttpPatch("{Id}/bookingReferences")]
    public async Task<ActionResult> UpdateReferences(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        try
        {
            await _service.UpdateReferences(uniqueId, bookingReferencesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Workflow Reminders records for Booking
    /// </summary>
    [HttpPatch("{Id}/workflowReminders")]
    public async Task<ActionResult> UpdateWorkflowReminders(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        try
        {
            await _service.UpdateWorkflowReminders(uniqueId, workflowRemindersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Create one Booking
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Booking>> CreateBooking(BookingCreateInput input)
    {
        var booking = await _service.CreateBooking(input);

        return CreatedAtAction(nameof(Booking), new { id = booking.Id }, booking);
    }

    /// <summary>
    /// Delete one Booking
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBooking([FromRoute()] BookingWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteBooking(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Bookings
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Booking>>> Bookings(
        [FromQuery()] BookingFindManyArgs filter
    )
    {
        return Ok(await _service.Bookings(filter));
    }

    /// <summary>
    /// Get one Booking
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Booking>> Booking([FromRoute()] BookingWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Booking(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Booking
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBooking(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] BookingUpdateInput bookingUpdateDto
    )
    {
        try
        {
            await _service.UpdateBooking(uniqueId, bookingUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
