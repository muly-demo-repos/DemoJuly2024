using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EventTypesControllerBase : ControllerBase
{
    protected readonly IEventTypesService _service;

    public EventTypesControllerBase(IEventTypesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Event Type
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<EventType>> CreateEventType(EventTypeCreateInput input)
    {
        var eventType = await _service.CreateEventType(input);

        return CreatedAtAction(nameof(EventType), new { id = eventType.Id }, eventType);
    }

    /// <summary>
    /// Delete one Event Type
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteEventType(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteEventType(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Availability records to Event Type
    /// </summary>
    [HttpPost("{Id}/availabilities")]
    public async Task<ActionResult> ConnectAvailability(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
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
    /// Connect multiple Booking records to Event Type
    /// </summary>
    [HttpPost("{Id}/bookings")]
    public async Task<ActionResult> ConnectBooking(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] BookingWhereUniqueInput[] bookingsId
    )
    {
        try
        {
            await _service.ConnectBooking(uniqueId, bookingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Event Type Custom Input records to Event Type
    /// </summary>
    [HttpPost("{Id}/eventTypeCustomInputs")]
    public async Task<ActionResult> ConnectEventTypeCustomInput(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        try
        {
            await _service.ConnectEventTypeCustomInput(uniqueId, eventTypeCustomInputsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Users records to Event Type
    /// </summary>
    [HttpPost("{Id}/users")]
    public async Task<ActionResult> ConnectUsers(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.ConnectUsers(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Webhook records to Event Type
    /// </summary>
    [HttpPost("{Id}/webhooks")]
    public async Task<ActionResult> ConnectWebhook(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] WebhookWhereUniqueInput[] webhooksId
    )
    {
        try
        {
            await _service.ConnectWebhook(uniqueId, webhooksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Workflows On Event Types records to Event Type
    /// </summary>
    [HttpPost("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> ConnectWorkflowsOnEventTypes(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.ConnectWorkflowsOnEventTypes(uniqueId, workflowsOnEventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Availability records from Event Type
    /// </summary>
    [HttpDelete("{Id}/availabilities")]
    public async Task<ActionResult> DisconnectAvailability(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Booking records from Event Type
    /// </summary>
    [HttpDelete("{Id}/bookings")]
    public async Task<ActionResult> DisconnectBooking(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] BookingWhereUniqueInput[] bookingsId
    )
    {
        try
        {
            await _service.DisconnectBooking(uniqueId, bookingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Event Type Custom Input records from Event Type
    /// </summary>
    [HttpDelete("{Id}/eventTypeCustomInputs")]
    public async Task<ActionResult> DisconnectEventTypeCustomInput(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        try
        {
            await _service.DisconnectEventTypeCustomInput(uniqueId, eventTypeCustomInputsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Users records from Event Type
    /// </summary>
    [HttpDelete("{Id}/users")]
    public async Task<ActionResult> DisconnectUsers(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.DisconnectUsers(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Webhook records from Event Type
    /// </summary>
    [HttpDelete("{Id}/webhooks")]
    public async Task<ActionResult> DisconnectWebhook(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] WebhookWhereUniqueInput[] webhooksId
    )
    {
        try
        {
            await _service.DisconnectWebhook(uniqueId, webhooksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Workflows On Event Types records from Event Type
    /// </summary>
    [HttpDelete("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> DisconnectWorkflowsOnEventTypes(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.DisconnectWorkflowsOnEventTypes(uniqueId, workflowsOnEventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Availability records for Event Type
    /// </summary>
    [HttpGet("{Id}/availabilities")]
    public async Task<ActionResult<List<Availability>>> FindAvailability(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
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
    /// Find multiple Booking records for Event Type
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> FindBooking(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] BookingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindBooking(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Event Type Custom Input records for Event Type
    /// </summary>
    [HttpGet("{Id}/eventTypeCustomInputs")]
    public async Task<ActionResult<List<EventTypeCustomInput>>> FindEventTypeCustomInput(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeCustomInputFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindEventTypeCustomInput(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Users records for Event Type
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> FindUsers(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] UserFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindUsers(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Webhook records for Event Type
    /// </summary>
    [HttpGet("{Id}/webhooks")]
    public async Task<ActionResult<List<Webhook>>> FindWebhook(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] WebhookFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWebhook(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Workflows On Event Types records for Event Type
    /// </summary>
    [HttpGet("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult<List<WorkflowsOnEventType>>> FindWorkflowsOnEventTypes(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowsOnEventTypeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWorkflowsOnEventTypes(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Destination Calendar record for Event Type
    /// </summary>
    [HttpGet("{Id}/destinationCalendars")]
    public async Task<ActionResult<List<DestinationCalendar>>> GetDestinationCalendar(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId
    )
    {
        var destinationCalendar = await _service.GetDestinationCalendar(uniqueId);
        return Ok(destinationCalendar);
    }

    /// <summary>
    /// Get a Hashed Link record for Event Type
    /// </summary>
    [HttpGet("{Id}/hashedLinks")]
    public async Task<ActionResult<List<HashedLink>>> GetHashedLink(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId
    )
    {
        var hashedLink = await _service.GetHashedLink(uniqueId);
        return Ok(hashedLink);
    }

    /// <summary>
    /// Get a Schedule record for Event Type
    /// </summary>
    [HttpGet("{Id}/schedules")]
    public async Task<ActionResult<List<Schedule>>> GetSchedule(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId
    )
    {
        var schedule = await _service.GetSchedule(uniqueId);
        return Ok(schedule);
    }

    /// <summary>
    /// Get a Team record for Event Type
    /// </summary>
    [HttpGet("{Id}/teams")]
    public async Task<ActionResult<List<Team>>> GetTeam(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId
    )
    {
        var team = await _service.GetTeam(uniqueId);
        return Ok(team);
    }

    /// <summary>
    /// Meta data about Event Type records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EventTypesMeta(
        [FromQuery()] EventTypeFindManyArgs filter
    )
    {
        return Ok(await _service.EventTypesMeta(filter));
    }

    /// <summary>
    /// Update multiple Availability records for Event Type
    /// </summary>
    [HttpPatch("{Id}/availabilities")]
    public async Task<ActionResult> UpdateAvailability(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
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
    /// Update multiple Booking records for Event Type
    /// </summary>
    [HttpPatch("{Id}/bookings")]
    public async Task<ActionResult> UpdateBooking(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] BookingWhereUniqueInput[] bookingsId
    )
    {
        try
        {
            await _service.UpdateBooking(uniqueId, bookingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Event Type Custom Input records for Event Type
    /// </summary>
    [HttpPatch("{Id}/eventTypeCustomInputs")]
    public async Task<ActionResult> UpdateEventTypeCustomInput(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        try
        {
            await _service.UpdateEventTypeCustomInput(uniqueId, eventTypeCustomInputsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Users records for Event Type
    /// </summary>
    [HttpPatch("{Id}/users")]
    public async Task<ActionResult> UpdateUsers(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.UpdateUsers(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Webhook records for Event Type
    /// </summary>
    [HttpPatch("{Id}/webhooks")]
    public async Task<ActionResult> UpdateWebhook(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] WebhookWhereUniqueInput[] webhooksId
    )
    {
        try
        {
            await _service.UpdateWebhook(uniqueId, webhooksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Workflows On Event Types records for Event Type
    /// </summary>
    [HttpPatch("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> UpdateWorkflowsOnEventTypes(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.UpdateWorkflowsOnEventTypes(uniqueId, workflowsOnEventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many EventTypes
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<EventType>>> EventTypes(
        [FromQuery()] EventTypeFindManyArgs filter
    )
    {
        return Ok(await _service.EventTypes(filter));
    }

    /// <summary>
    /// Get one Event Type
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<EventType>> EventType(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.EventType(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Event Type
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateEventType(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeUpdateInput eventTypeUpdateDto
    )
    {
        try
        {
            await _service.UpdateEventType(uniqueId, eventTypeUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
