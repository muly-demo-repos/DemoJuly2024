using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class UsersControllerBase : ControllerBase
{
    protected readonly IUsersService _service;

    public UsersControllerBase(IUsersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<User>> CreateUser(UserCreateInput input)
    {
        var user = await _service.CreateUser(input);

        return CreatedAtAction(nameof(User), new { id = user.Id }, user);
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteUser([FromRoute()] UserWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteUser(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<User>>> Users([FromQuery()] UserFindManyArgs filter)
    {
        return Ok(await _service.Users(filter));
    }

    /// <summary>
    /// Get one User
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<User>> User([FromRoute()] UserWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.User(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one User
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateUser(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] UserUpdateInput userUpdateDto
    )
    {
        try
        {
            await _service.UpdateUser(uniqueId, userUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Accounts records to User
    /// </summary>
    [HttpPost("{Id}/accounts")]
    public async Task<ActionResult> ConnectAccounts(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AccountWhereUniqueInput[] accountsId
    )
    {
        try
        {
            await _service.ConnectAccounts(uniqueId, accountsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Api Keys records to User
    /// </summary>
    [HttpPost("{Id}/apiKeys")]
    public async Task<ActionResult> ConnectApiKeys(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        try
        {
            await _service.ConnectApiKeys(uniqueId, apiKeysId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Availability records to User
    /// </summary>
    [HttpPost("{Id}/availabilities")]
    public async Task<ActionResult> ConnectAvailability(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Connect multiple Bookings records to User
    /// </summary>
    [HttpPost("{Id}/bookings")]
    public async Task<ActionResult> ConnectBookings(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Connect multiple Credentials records to User
    /// </summary>
    [HttpPost("{Id}/credentials")]
    public async Task<ActionResult> ConnectCredentials(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CredentialWhereUniqueInput[] credentialsId
    )
    {
        try
        {
            await _service.ConnectCredentials(uniqueId, credentialsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Event Types records to User
    /// </summary>
    [HttpPost("{Id}/eventTypes")]
    public async Task<ActionResult> ConnectEventTypes(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.ConnectEventTypes(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Feedback records to User
    /// </summary>
    [HttpPost("{Id}/feedbacks")]
    public async Task<ActionResult> ConnectFeedback(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] FeedbackWhereUniqueInput[] feedbacksId
    )
    {
        try
        {
            await _service.ConnectFeedback(uniqueId, feedbacksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Impersonated By records to User
    /// </summary>
    [HttpPost("{Id}/impersonations")]
    public async Task<ActionResult> ConnectImpersonatedBy(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.ConnectImpersonatedUsers(uniqueId, impersonationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Impersonated Users records to User
    /// </summary>
    [HttpPost("{Id}/impersonations")]
    public async Task<ActionResult> ConnectImpersonatedUsers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.ConnectImpersonatedUsers(uniqueId, impersonationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Schedules records to User
    /// </summary>
    [HttpPost("{Id}/schedules")]
    public async Task<ActionResult> ConnectSchedules(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ScheduleWhereUniqueInput[] schedulesId
    )
    {
        try
        {
            await _service.ConnectSchedules(uniqueId, schedulesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Selected Calendars records to User
    /// </summary>
    [HttpPost("{Id}/selectedCalendars")]
    public async Task<ActionResult> ConnectSelectedCalendars(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        try
        {
            await _service.ConnectSelectedCalendars(uniqueId, selectedCalendarsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Sessions records to User
    /// </summary>
    [HttpPost("{Id}/sessions")]
    public async Task<ActionResult> ConnectSessions(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] SessionWhereUniqueInput[] sessionsId
    )
    {
        try
        {
            await _service.ConnectSessions(uniqueId, sessionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Teams records to User
    /// </summary>
    [HttpPost("{Id}/memberships")]
    public async Task<ActionResult> ConnectTeams(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.ConnectTeams(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Webhooks records to User
    /// </summary>
    [HttpPost("{Id}/webhooks")]
    public async Task<ActionResult> ConnectWebhooks(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Connect multiple Workflows records to User
    /// </summary>
    [HttpPost("{Id}/workflows")]
    public async Task<ActionResult> ConnectWorkflows(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowWhereUniqueInput[] workflowsId
    )
    {
        try
        {
            await _service.ConnectWorkflows(uniqueId, workflowsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Accounts records from User
    /// </summary>
    [HttpDelete("{Id}/accounts")]
    public async Task<ActionResult> DisconnectAccounts(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AccountWhereUniqueInput[] accountsId
    )
    {
        try
        {
            await _service.DisconnectAccounts(uniqueId, accountsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Api Keys records from User
    /// </summary>
    [HttpDelete("{Id}/apiKeys")]
    public async Task<ActionResult> DisconnectApiKeys(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        try
        {
            await _service.DisconnectApiKeys(uniqueId, apiKeysId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Availability records from User
    /// </summary>
    [HttpDelete("{Id}/availabilities")]
    public async Task<ActionResult> DisconnectAvailability(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Bookings records from User
    /// </summary>
    [HttpDelete("{Id}/bookings")]
    public async Task<ActionResult> DisconnectBookings(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Credentials records from User
    /// </summary>
    [HttpDelete("{Id}/credentials")]
    public async Task<ActionResult> DisconnectCredentials(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CredentialWhereUniqueInput[] credentialsId
    )
    {
        try
        {
            await _service.DisconnectCredentials(uniqueId, credentialsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Event Types records from User
    /// </summary>
    [HttpDelete("{Id}/eventTypes")]
    public async Task<ActionResult> DisconnectEventTypes(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.DisconnectEventTypes(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Feedback records from User
    /// </summary>
    [HttpDelete("{Id}/feedbacks")]
    public async Task<ActionResult> DisconnectFeedback(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] FeedbackWhereUniqueInput[] feedbacksId
    )
    {
        try
        {
            await _service.DisconnectFeedback(uniqueId, feedbacksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Impersonated By records from User
    /// </summary>
    [HttpDelete("{Id}/impersonations")]
    public async Task<ActionResult> DisconnectImpersonatedBy(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.DisconnectImpersonatedUsers(uniqueId, impersonationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Impersonated Users records from User
    /// </summary>
    [HttpDelete("{Id}/impersonations")]
    public async Task<ActionResult> DisconnectImpersonatedUsers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.DisconnectImpersonatedUsers(uniqueId, impersonationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Schedules records from User
    /// </summary>
    [HttpDelete("{Id}/schedules")]
    public async Task<ActionResult> DisconnectSchedules(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ScheduleWhereUniqueInput[] schedulesId
    )
    {
        try
        {
            await _service.DisconnectSchedules(uniqueId, schedulesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Selected Calendars records from User
    /// </summary>
    [HttpDelete("{Id}/selectedCalendars")]
    public async Task<ActionResult> DisconnectSelectedCalendars(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        try
        {
            await _service.DisconnectSelectedCalendars(uniqueId, selectedCalendarsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Sessions records from User
    /// </summary>
    [HttpDelete("{Id}/sessions")]
    public async Task<ActionResult> DisconnectSessions(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] SessionWhereUniqueInput[] sessionsId
    )
    {
        try
        {
            await _service.DisconnectSessions(uniqueId, sessionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Teams records from User
    /// </summary>
    [HttpDelete("{Id}/memberships")]
    public async Task<ActionResult> DisconnectTeams(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.DisconnectTeams(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Webhooks records from User
    /// </summary>
    [HttpDelete("{Id}/webhooks")]
    public async Task<ActionResult> DisconnectWebhooks(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Workflows records from User
    /// </summary>
    [HttpDelete("{Id}/workflows")]
    public async Task<ActionResult> DisconnectWorkflows(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WorkflowWhereUniqueInput[] workflowsId
    )
    {
        try
        {
            await _service.DisconnectWorkflows(uniqueId, workflowsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Accounts records for User
    /// </summary>
    [HttpGet("{Id}/accounts")]
    public async Task<ActionResult<List<Account>>> FindAccounts(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AccountFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAccounts(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Api Keys records for User
    /// </summary>
    [HttpGet("{Id}/apiKeys")]
    public async Task<ActionResult<List<ApiKey>>> FindApiKeys(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ApiKeyFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindApiKeys(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Availability records for User
    /// </summary>
    [HttpGet("{Id}/availabilities")]
    public async Task<ActionResult<List<Availability>>> FindAvailability(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Find multiple Bookings records for User
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> FindBookings(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Find multiple Credentials records for User
    /// </summary>
    [HttpGet("{Id}/credentials")]
    public async Task<ActionResult<List<Credential>>> FindCredentials(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CredentialFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindCredentials(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Event Types records for User
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> FindEventTypes(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindEventTypes(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Feedback records for User
    /// </summary>
    [HttpGet("{Id}/feedbacks")]
    public async Task<ActionResult<List<Feedback>>> FindFeedback(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] FeedbackFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindFeedback(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Impersonated By records for User
    /// </summary>
    [HttpGet("{Id}/impersonations")]
    public async Task<ActionResult<List<Impersonation>>> FindImpersonatedBy(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ImpersonationFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindImpersonatedUsers(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Impersonated Users records for User
    /// </summary>
    [HttpGet("{Id}/impersonations")]
    public async Task<ActionResult<List<Impersonation>>> FindImpersonatedUsers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ImpersonationFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindImpersonatedUsers(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Schedules records for User
    /// </summary>
    [HttpGet("{Id}/schedules")]
    public async Task<ActionResult<List<Schedule>>> FindSchedules(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ScheduleFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSchedules(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Selected Calendars records for User
    /// </summary>
    [HttpGet("{Id}/selectedCalendars")]
    public async Task<ActionResult<List<SelectedCalendar>>> FindSelectedCalendars(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] SelectedCalendarFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSelectedCalendars(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Sessions records for User
    /// </summary>
    [HttpGet("{Id}/sessions")]
    public async Task<ActionResult<List<Session>>> FindSessions(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] SessionFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSessions(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Teams records for User
    /// </summary>
    [HttpGet("{Id}/memberships")]
    public async Task<ActionResult<List<Membership>>> FindTeams(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] MembershipFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindTeams(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Webhooks records for User
    /// </summary>
    [HttpGet("{Id}/webhooks")]
    public async Task<ActionResult<List<Webhook>>> FindWebhooks(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Find multiple Workflows records for User
    /// </summary>
    [HttpGet("{Id}/workflows")]
    public async Task<ActionResult<List<Workflow>>> FindWorkflows(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowFindManyArgs filter
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
    /// Get a Destination Calendar record for User
    /// </summary>
    [HttpGet("{Id}/destinationCalendars")]
    public async Task<ActionResult<List<DestinationCalendar>>> GetDestinationCalendar(
        [FromRoute()] UserWhereUniqueInput uniqueId
    )
    {
        var destinationCalendar = await _service.GetDestinationCalendar(uniqueId);
        return Ok(destinationCalendar);
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> UsersMeta([FromQuery()] UserFindManyArgs filter)
    {
        return Ok(await _service.UsersMeta(filter));
    }

    /// <summary>
    /// Update multiple Accounts records for User
    /// </summary>
    [HttpPatch("{Id}/accounts")]
    public async Task<ActionResult> UpdateAccounts(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AccountWhereUniqueInput[] accountsId
    )
    {
        try
        {
            await _service.UpdateAccounts(uniqueId, accountsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Api Keys records for User
    /// </summary>
    [HttpPatch("{Id}/apiKeys")]
    public async Task<ActionResult> UpdateApiKeys(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        try
        {
            await _service.UpdateApiKeys(uniqueId, apiKeysId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Availability records for User
    /// </summary>
    [HttpPatch("{Id}/availabilities")]
    public async Task<ActionResult> UpdateAvailability(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Update multiple Bookings records for User
    /// </summary>
    [HttpPatch("{Id}/bookings")]
    public async Task<ActionResult> UpdateBookings(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Update multiple Credentials records for User
    /// </summary>
    [HttpPatch("{Id}/credentials")]
    public async Task<ActionResult> UpdateCredentials(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CredentialWhereUniqueInput[] credentialsId
    )
    {
        try
        {
            await _service.UpdateCredentials(uniqueId, credentialsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Event Types records for User
    /// </summary>
    [HttpPatch("{Id}/eventTypes")]
    public async Task<ActionResult> UpdateEventTypes(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.UpdateEventTypes(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Feedback records for User
    /// </summary>
    [HttpPatch("{Id}/feedbacks")]
    public async Task<ActionResult> UpdateFeedback(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] FeedbackWhereUniqueInput[] feedbacksId
    )
    {
        try
        {
            await _service.UpdateFeedback(uniqueId, feedbacksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Impersonated By records for User
    /// </summary>
    [HttpPatch("{Id}/impersonations")]
    public async Task<ActionResult> UpdateImpersonatedBy(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.UpdateImpersonatedUsers(uniqueId, impersonationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Impersonated Users records for User
    /// </summary>
    [HttpPatch("{Id}/impersonations")]
    public async Task<ActionResult> UpdateImpersonatedUsers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.UpdateImpersonatedUsers(uniqueId, impersonationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Schedules records for User
    /// </summary>
    [HttpPatch("{Id}/schedules")]
    public async Task<ActionResult> UpdateSchedules(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ScheduleWhereUniqueInput[] schedulesId
    )
    {
        try
        {
            await _service.UpdateSchedules(uniqueId, schedulesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Selected Calendars records for User
    /// </summary>
    [HttpPatch("{Id}/selectedCalendars")]
    public async Task<ActionResult> UpdateSelectedCalendars(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        try
        {
            await _service.UpdateSelectedCalendars(uniqueId, selectedCalendarsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Sessions records for User
    /// </summary>
    [HttpPatch("{Id}/sessions")]
    public async Task<ActionResult> UpdateSessions(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] SessionWhereUniqueInput[] sessionsId
    )
    {
        try
        {
            await _service.UpdateSessions(uniqueId, sessionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Teams records for User
    /// </summary>
    [HttpPatch("{Id}/memberships")]
    public async Task<ActionResult> UpdateTeams(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.UpdateTeams(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Webhooks records for User
    /// </summary>
    [HttpPatch("{Id}/webhooks")]
    public async Task<ActionResult> UpdateWebhooks(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Update multiple Workflows records for User
    /// </summary>
    [HttpPatch("{Id}/workflows")]
    public async Task<ActionResult> UpdateWorkflows(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WorkflowWhereUniqueInput[] workflowsId
    )
    {
        try
        {
            await _service.UpdateWorkflows(uniqueId, workflowsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
