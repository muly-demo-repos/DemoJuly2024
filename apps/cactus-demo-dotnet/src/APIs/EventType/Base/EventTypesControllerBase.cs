using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

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
    /// Connect multiple Bookings records to Event Type
    /// </summary>
    [HttpPost("{Id}/bookings")]
    public async Task<ActionResult> ConnectBookings(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] BookingWhereUniqueInput[] bookingsId
    )
    {
        try
        {
            await _service.ConnectBookings(uniqueId, bookingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Custom Inputs records to Event Type
    /// </summary>
    [HttpPost("{Id}/eventTypeCustomInputs")]
    public async Task<ActionResult> ConnectCustomInputs(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        try
        {
            await _service.ConnectCustomInputs(uniqueId, eventTypeCustomInputsId);
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
    /// Connect multiple Webhooks records to Event Type
    /// </summary>
    [HttpPost("{Id}/webhooks")]
    public async Task<ActionResult> ConnectWebhooks(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] WebhookWhereUniqueInput[] webhooksId
    )
    {
        try
        {
            await _service.ConnectWebhooks(uniqueId, webhooksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Workflows records to Event Type
    /// </summary>
    [HttpPost("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> ConnectWorkflows(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.ConnectWorkflows(uniqueId, workflowsOnEventTypesId);
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
    /// Disconnect multiple Bookings records from Event Type
    /// </summary>
    [HttpDelete("{Id}/bookings")]
    public async Task<ActionResult> DisconnectBookings(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] BookingWhereUniqueInput[] bookingsId
    )
    {
        try
        {
            await _service.DisconnectBookings(uniqueId, bookingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Custom Inputs records from Event Type
    /// </summary>
    [HttpDelete("{Id}/eventTypeCustomInputs")]
    public async Task<ActionResult> DisconnectCustomInputs(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        try
        {
            await _service.DisconnectCustomInputs(uniqueId, eventTypeCustomInputsId);
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
    /// Disconnect multiple Webhooks records from Event Type
    /// </summary>
    [HttpDelete("{Id}/webhooks")]
    public async Task<ActionResult> DisconnectWebhooks(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] WebhookWhereUniqueInput[] webhooksId
    )
    {
        try
        {
            await _service.DisconnectWebhooks(uniqueId, webhooksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Workflows records from Event Type
    /// </summary>
    [HttpDelete("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> DisconnectWorkflows(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.DisconnectWorkflows(uniqueId, workflowsOnEventTypesId);
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
    /// Find multiple Bookings records for Event Type
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> FindBookings(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] BookingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindBookings(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Custom Inputs records for Event Type
    /// </summary>
    [HttpGet("{Id}/eventTypeCustomInputs")]
    public async Task<ActionResult<List<EventTypeCustomInput>>> FindCustomInputs(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeCustomInputFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindCustomInputs(uniqueId, filter));
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
    /// Find multiple Webhooks records for Event Type
    /// </summary>
    [HttpGet("{Id}/webhooks")]
    public async Task<ActionResult<List<Webhook>>> FindWebhooks(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] WebhookFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWebhooks(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Workflows records for Event Type
    /// </summary>
    [HttpGet("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult<List<WorkflowsOnEventType>>> FindWorkflows(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowsOnEventTypeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWorkflows(uniqueId, filter));
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
    /// Update multiple Bookings records for Event Type
    /// </summary>
    [HttpPatch("{Id}/bookings")]
    public async Task<ActionResult> UpdateBookings(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] BookingWhereUniqueInput[] bookingsId
    )
    {
        try
        {
            await _service.UpdateBookings(uniqueId, bookingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Custom Inputs records for Event Type
    /// </summary>
    [HttpPatch("{Id}/eventTypeCustomInputs")]
    public async Task<ActionResult> UpdateCustomInputs(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    )
    {
        try
        {
            await _service.UpdateCustomInputs(uniqueId, eventTypeCustomInputsId);
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
    /// Update multiple Webhooks records for Event Type
    /// </summary>
    [HttpPatch("{Id}/webhooks")]
    public async Task<ActionResult> UpdateWebhooks(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] WebhookWhereUniqueInput[] webhooksId
    )
    {
        try
        {
            await _service.UpdateWebhooks(uniqueId, webhooksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Workflows records for Event Type
    /// </summary>
    [HttpPatch("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> UpdateWorkflows(
        [FromRoute()] EventTypeWhereUniqueInput uniqueId,
        [FromBody()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.UpdateWorkflows(uniqueId, workflowsOnEventTypesId);
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
