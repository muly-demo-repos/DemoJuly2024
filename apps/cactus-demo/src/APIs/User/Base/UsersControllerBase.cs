using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

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
    /// Connect multiple Account records to User
    /// </summary>
    [HttpPost("{Id}/accounts")]
    public async Task<ActionResult> ConnectAccount(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AccountWhereUniqueInput[] accountsId
    )
    {
        try
        {
            await _service.ConnectAccount(uniqueId, accountsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Api Key records to User
    /// </summary>
    [HttpPost("{Id}/apiKeys")]
    public async Task<ActionResult> ConnectApiKey(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        try
        {
            await _service.ConnectApiKey(uniqueId, apiKeysId);
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
    /// Connect multiple Booking records to User
    /// </summary>
    [HttpPost("{Id}/bookings")]
    public async Task<ActionResult> ConnectBooking(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Connect multiple Credential records to User
    /// </summary>
    [HttpPost("{Id}/credentials")]
    public async Task<ActionResult> ConnectCredential(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CredentialWhereUniqueInput[] credentialsId
    )
    {
        try
        {
            await _service.ConnectCredential(uniqueId, credentialsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Event Type records to User
    /// </summary>
    [HttpPost("{Id}/eventTypes")]
    public async Task<ActionResult> ConnectEventType(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Connect multiple Impersonations Impersonations Impersonated By Id Tousers records to User
    /// </summary>
    [HttpPost("{Id}/impersonations")]
    public async Task<ActionResult> ConnectImpersonationsImpersonationsImpersonatedByIdTousers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.ConnectImpersonationsImpersonationsImpersonatedByIdTousers(
                uniqueId,
                impersonationsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Impersonations Impersonations Impersonated User Id Tousers records to User
    /// </summary>
    [HttpPost("{Id}/impersonations")]
    public async Task<ActionResult> ConnectImpersonationsImpersonationsImpersonatedUserIdTousers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.ConnectImpersonationsImpersonationsImpersonatedByIdTousers(
                uniqueId,
                impersonationsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Membership records to User
    /// </summary>
    [HttpPost("{Id}/memberships")]
    public async Task<ActionResult> ConnectMembership(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.ConnectMembership(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Schedule records to User
    /// </summary>
    [HttpPost("{Id}/schedules")]
    public async Task<ActionResult> ConnectSchedule(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ScheduleWhereUniqueInput[] schedulesId
    )
    {
        try
        {
            await _service.ConnectSchedule(uniqueId, schedulesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Selected Calendar records to User
    /// </summary>
    [HttpPost("{Id}/selectedCalendars")]
    public async Task<ActionResult> ConnectSelectedCalendar(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        try
        {
            await _service.ConnectSelectedCalendar(uniqueId, selectedCalendarsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Session records to User
    /// </summary>
    [HttpPost("{Id}/sessions")]
    public async Task<ActionResult> ConnectSession(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] SessionWhereUniqueInput[] sessionsId
    )
    {
        try
        {
            await _service.ConnectSession(uniqueId, sessionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Webhook records to User
    /// </summary>
    [HttpPost("{Id}/webhooks")]
    public async Task<ActionResult> ConnectWebhook(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Connect multiple Workflow records to User
    /// </summary>
    [HttpPost("{Id}/workflows")]
    public async Task<ActionResult> ConnectWorkflow(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowWhereUniqueInput[] workflowsId
    )
    {
        try
        {
            await _service.ConnectWorkflow(uniqueId, workflowsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Account records from User
    /// </summary>
    [HttpDelete("{Id}/accounts")]
    public async Task<ActionResult> DisconnectAccount(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AccountWhereUniqueInput[] accountsId
    )
    {
        try
        {
            await _service.DisconnectAccount(uniqueId, accountsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Api Key records from User
    /// </summary>
    [HttpDelete("{Id}/apiKeys")]
    public async Task<ActionResult> DisconnectApiKey(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        try
        {
            await _service.DisconnectApiKey(uniqueId, apiKeysId);
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
    /// Disconnect multiple Booking records from User
    /// </summary>
    [HttpDelete("{Id}/bookings")]
    public async Task<ActionResult> DisconnectBooking(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Credential records from User
    /// </summary>
    [HttpDelete("{Id}/credentials")]
    public async Task<ActionResult> DisconnectCredential(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CredentialWhereUniqueInput[] credentialsId
    )
    {
        try
        {
            await _service.DisconnectCredential(uniqueId, credentialsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Event Type records from User
    /// </summary>
    [HttpDelete("{Id}/eventTypes")]
    public async Task<ActionResult> DisconnectEventType(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Impersonations Impersonations Impersonated By Id Tousers records from User
    /// </summary>
    [HttpDelete("{Id}/impersonations")]
    public async Task<ActionResult> DisconnectImpersonationsImpersonationsImpersonatedByIdTousers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.DisconnectImpersonationsImpersonationsImpersonatedByIdTousers(
                uniqueId,
                impersonationsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Impersonations Impersonations Impersonated User Id Tousers records from User
    /// </summary>
    [HttpDelete("{Id}/impersonations")]
    public async Task<ActionResult> DisconnectImpersonationsImpersonationsImpersonatedUserIdTousers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.DisconnectImpersonationsImpersonationsImpersonatedByIdTousers(
                uniqueId,
                impersonationsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Membership records from User
    /// </summary>
    [HttpDelete("{Id}/memberships")]
    public async Task<ActionResult> DisconnectMembership(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.DisconnectMembership(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Schedule records from User
    /// </summary>
    [HttpDelete("{Id}/schedules")]
    public async Task<ActionResult> DisconnectSchedule(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ScheduleWhereUniqueInput[] schedulesId
    )
    {
        try
        {
            await _service.DisconnectSchedule(uniqueId, schedulesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Selected Calendar records from User
    /// </summary>
    [HttpDelete("{Id}/selectedCalendars")]
    public async Task<ActionResult> DisconnectSelectedCalendar(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        try
        {
            await _service.DisconnectSelectedCalendar(uniqueId, selectedCalendarsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Session records from User
    /// </summary>
    [HttpDelete("{Id}/sessions")]
    public async Task<ActionResult> DisconnectSession(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] SessionWhereUniqueInput[] sessionsId
    )
    {
        try
        {
            await _service.DisconnectSession(uniqueId, sessionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Webhook records from User
    /// </summary>
    [HttpDelete("{Id}/webhooks")]
    public async Task<ActionResult> DisconnectWebhook(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Workflow records from User
    /// </summary>
    [HttpDelete("{Id}/workflows")]
    public async Task<ActionResult> DisconnectWorkflow(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WorkflowWhereUniqueInput[] workflowsId
    )
    {
        try
        {
            await _service.DisconnectWorkflow(uniqueId, workflowsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Account records for User
    /// </summary>
    [HttpGet("{Id}/accounts")]
    public async Task<ActionResult<List<Account>>> FindAccount(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AccountFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAccount(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Api Key records for User
    /// </summary>
    [HttpGet("{Id}/apiKeys")]
    public async Task<ActionResult<List<ApiKey>>> FindApiKey(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ApiKeyFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindApiKey(uniqueId, filter));
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
    /// Find multiple Booking records for User
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> FindBooking(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Find multiple Credential records for User
    /// </summary>
    [HttpGet("{Id}/credentials")]
    public async Task<ActionResult<List<Credential>>> FindCredential(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CredentialFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindCredential(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Event Type records for User
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> FindEventType(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Find multiple Impersonations Impersonations Impersonated By Id Tousers records for User
    /// </summary>
    [HttpGet("{Id}/impersonations")]
    public async Task<
        ActionResult<List<Impersonation>>
    > FindImpersonationsImpersonationsImpersonatedByIdTousers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ImpersonationFindManyArgs filter
    )
    {
        try
        {
            return Ok(
                await _service.FindImpersonationsImpersonationsImpersonatedByIdTousers(
                    uniqueId,
                    filter
                )
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Impersonations Impersonations Impersonated User Id Tousers records for User
    /// </summary>
    [HttpGet("{Id}/impersonations")]
    public async Task<
        ActionResult<List<Impersonation>>
    > FindImpersonationsImpersonationsImpersonatedUserIdTousers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ImpersonationFindManyArgs filter
    )
    {
        try
        {
            return Ok(
                await _service.FindImpersonationsImpersonationsImpersonatedByIdTousers(
                    uniqueId,
                    filter
                )
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Membership records for User
    /// </summary>
    [HttpGet("{Id}/memberships")]
    public async Task<ActionResult<List<Membership>>> FindMembership(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] MembershipFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindMembership(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Schedule records for User
    /// </summary>
    [HttpGet("{Id}/schedules")]
    public async Task<ActionResult<List<Schedule>>> FindSchedule(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ScheduleFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSchedule(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Selected Calendar records for User
    /// </summary>
    [HttpGet("{Id}/selectedCalendars")]
    public async Task<ActionResult<List<SelectedCalendar>>> FindSelectedCalendar(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] SelectedCalendarFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSelectedCalendar(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Session records for User
    /// </summary>
    [HttpGet("{Id}/sessions")]
    public async Task<ActionResult<List<Session>>> FindSession(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] SessionFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSession(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Webhook records for User
    /// </summary>
    [HttpGet("{Id}/webhooks")]
    public async Task<ActionResult<List<Webhook>>> FindWebhook(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Find multiple Workflow records for User
    /// </summary>
    [HttpGet("{Id}/workflows")]
    public async Task<ActionResult<List<Workflow>>> FindWorkflow(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWorkflow(uniqueId, filter));
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
    /// Update multiple Account records for User
    /// </summary>
    [HttpPatch("{Id}/accounts")]
    public async Task<ActionResult> UpdateAccount(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AccountWhereUniqueInput[] accountsId
    )
    {
        try
        {
            await _service.UpdateAccount(uniqueId, accountsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Api Key records for User
    /// </summary>
    [HttpPatch("{Id}/apiKeys")]
    public async Task<ActionResult> UpdateApiKey(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        try
        {
            await _service.UpdateApiKey(uniqueId, apiKeysId);
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
    /// Update multiple Booking records for User
    /// </summary>
    [HttpPatch("{Id}/bookings")]
    public async Task<ActionResult> UpdateBooking(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Update multiple Credential records for User
    /// </summary>
    [HttpPatch("{Id}/credentials")]
    public async Task<ActionResult> UpdateCredential(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CredentialWhereUniqueInput[] credentialsId
    )
    {
        try
        {
            await _service.UpdateCredential(uniqueId, credentialsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Event Type records for User
    /// </summary>
    [HttpPatch("{Id}/eventTypes")]
    public async Task<ActionResult> UpdateEventType(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Update multiple Impersonations Impersonations Impersonated By Id Tousers records for User
    /// </summary>
    [HttpPatch("{Id}/impersonations")]
    public async Task<ActionResult> UpdateImpersonationsImpersonationsImpersonatedByIdTousers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.UpdateImpersonationsImpersonationsImpersonatedByIdTousers(
                uniqueId,
                impersonationsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Impersonations Impersonations Impersonated User Id Tousers records for User
    /// </summary>
    [HttpPatch("{Id}/impersonations")]
    public async Task<ActionResult> UpdateImpersonationsImpersonationsImpersonatedUserIdTousers(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        try
        {
            await _service.UpdateImpersonationsImpersonationsImpersonatedByIdTousers(
                uniqueId,
                impersonationsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Membership records for User
    /// </summary>
    [HttpPatch("{Id}/memberships")]
    public async Task<ActionResult> UpdateMembership(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.UpdateMembership(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Schedule records for User
    /// </summary>
    [HttpPatch("{Id}/schedules")]
    public async Task<ActionResult> UpdateSchedule(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ScheduleWhereUniqueInput[] schedulesId
    )
    {
        try
        {
            await _service.UpdateSchedule(uniqueId, schedulesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Selected Calendar records for User
    /// </summary>
    [HttpPatch("{Id}/selectedCalendars")]
    public async Task<ActionResult> UpdateSelectedCalendar(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        try
        {
            await _service.UpdateSelectedCalendar(uniqueId, selectedCalendarsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Session records for User
    /// </summary>
    [HttpPatch("{Id}/sessions")]
    public async Task<ActionResult> UpdateSession(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] SessionWhereUniqueInput[] sessionsId
    )
    {
        try
        {
            await _service.UpdateSession(uniqueId, sessionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Webhook records for User
    /// </summary>
    [HttpPatch("{Id}/webhooks")]
    public async Task<ActionResult> UpdateWebhook(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Update multiple Workflow records for User
    /// </summary>
    [HttpPatch("{Id}/workflows")]
    public async Task<ActionResult> UpdateWorkflow(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WorkflowWhereUniqueInput[] workflowsId
    )
    {
        try
        {
            await _service.UpdateWorkflow(uniqueId, workflowsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
