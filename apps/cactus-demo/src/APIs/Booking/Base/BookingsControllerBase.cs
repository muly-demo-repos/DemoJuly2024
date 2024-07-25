using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

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
    /// Connect multiple Attendee records to Booking
    /// </summary>
    [HttpPost("{Id}/attendees")]
    public async Task<ActionResult> ConnectAttendee(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] AttendeeWhereUniqueInput[] attendeesId
    )
    {
        try
        {
            await _service.ConnectAttendee(uniqueId, attendeesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Booking Reference records to Booking
    /// </summary>
    [HttpPost("{Id}/bookingReferences")]
    public async Task<ActionResult> ConnectBookingReference(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        try
        {
            await _service.ConnectBookingReference(uniqueId, bookingReferencesId);
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
    /// Connect multiple Workflow Reminder records to Booking
    /// </summary>
    [HttpPost("{Id}/workflowReminders")]
    public async Task<ActionResult> ConnectWorkflowReminder(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        try
        {
            await _service.ConnectWorkflowReminder(uniqueId, workflowRemindersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Attendee records from Booking
    /// </summary>
    [HttpDelete("{Id}/attendees")]
    public async Task<ActionResult> DisconnectAttendee(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] AttendeeWhereUniqueInput[] attendeesId
    )
    {
        try
        {
            await _service.DisconnectAttendee(uniqueId, attendeesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Booking Reference records from Booking
    /// </summary>
    [HttpDelete("{Id}/bookingReferences")]
    public async Task<ActionResult> DisconnectBookingReference(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        try
        {
            await _service.DisconnectBookingReference(uniqueId, bookingReferencesId);
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
    /// Disconnect multiple Workflow Reminder records from Booking
    /// </summary>
    [HttpDelete("{Id}/workflowReminders")]
    public async Task<ActionResult> DisconnectWorkflowReminder(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        try
        {
            await _service.DisconnectWorkflowReminder(uniqueId, workflowRemindersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Attendee records for Booking
    /// </summary>
    [HttpGet("{Id}/attendees")]
    public async Task<ActionResult<List<Attendee>>> FindAttendee(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] AttendeeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAttendee(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Booking Reference records for Booking
    /// </summary>
    [HttpGet("{Id}/bookingReferences")]
    public async Task<ActionResult<List<BookingReference>>> FindBookingReference(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] BookingReferenceFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindBookingReference(uniqueId, filter));
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
    /// Find multiple Workflow Reminder records for Booking
    /// </summary>
    [HttpGet("{Id}/workflowReminders")]
    public async Task<ActionResult<List<WorkflowReminder>>> FindWorkflowReminder(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowReminderFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWorkflowReminder(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Daily Event Reference record for Booking
    /// </summary>
    [HttpGet("{Id}/dailyEventReferences")]
    public async Task<ActionResult<List<DailyEventReference>>> GetDailyEventReference(
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
    /// Get a Users record for Booking
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUsers(
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
    /// Update multiple Attendee records for Booking
    /// </summary>
    [HttpPatch("{Id}/attendees")]
    public async Task<ActionResult> UpdateAttendee(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] AttendeeWhereUniqueInput[] attendeesId
    )
    {
        try
        {
            await _service.UpdateAttendee(uniqueId, attendeesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Booking Reference records for Booking
    /// </summary>
    [HttpPatch("{Id}/bookingReferences")]
    public async Task<ActionResult> UpdateBookingReference(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        try
        {
            await _service.UpdateBookingReference(uniqueId, bookingReferencesId);
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
    /// Update multiple Workflow Reminder records for Booking
    /// </summary>
    [HttpPatch("{Id}/workflowReminders")]
    public async Task<ActionResult> UpdateWorkflowReminder(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromBody()] WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        try
        {
            await _service.UpdateWorkflowReminder(uniqueId, workflowRemindersId);
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
