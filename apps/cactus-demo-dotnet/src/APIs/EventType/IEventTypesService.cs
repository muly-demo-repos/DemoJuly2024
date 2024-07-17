using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IEventTypesService
{
    /// <summary>
    /// Create one Event Type
    /// </summary>
    public Task<EventType> CreateEventType(EventTypeCreateInput eventtype);

    /// <summary>
    /// Delete one Event Type
    /// </summary>
    public Task DeleteEventType(EventTypeWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Availability records to Event Type
    /// </summary>
    public Task ConnectAvailability(
        EventTypeWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Connect multiple Bookings records to Event Type
    /// </summary>
    public Task ConnectBookings(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Connect multiple Custom Inputs records to Event Type
    /// </summary>
    public Task ConnectCustomInputs(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    );

    /// <summary>
    /// Connect multiple Users records to Event Type
    /// </summary>
    public Task ConnectUsers(EventTypeWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Connect multiple Webhooks records to Event Type
    /// </summary>
    public Task ConnectWebhooks(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Connect multiple Workflows records to Event Type
    /// </summary>
    public Task ConnectWorkflows(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    );

    /// <summary>
    /// Disconnect multiple Availability records from Event Type
    /// </summary>
    public Task DisconnectAvailability(
        EventTypeWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Disconnect multiple Bookings records from Event Type
    /// </summary>
    public Task DisconnectBookings(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Disconnect multiple Custom Inputs records from Event Type
    /// </summary>
    public Task DisconnectCustomInputs(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    );

    /// <summary>
    /// Disconnect multiple Users records from Event Type
    /// </summary>
    public Task DisconnectUsers(EventTypeWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Disconnect multiple Webhooks records from Event Type
    /// </summary>
    public Task DisconnectWebhooks(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Disconnect multiple Workflows records from Event Type
    /// </summary>
    public Task DisconnectWorkflows(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    );

    /// <summary>
    /// Find multiple Availability records for Event Type
    /// </summary>
    public Task<List<Availability>> FindAvailability(
        EventTypeWhereUniqueInput uniqueId,
        AvailabilityFindManyArgs AvailabilityFindManyArgs
    );

    /// <summary>
    /// Find multiple Bookings records for Event Type
    /// </summary>
    public Task<List<Booking>> FindBookings(
        EventTypeWhereUniqueInput uniqueId,
        BookingFindManyArgs BookingFindManyArgs
    );

    /// <summary>
    /// Find multiple Custom Inputs records for Event Type
    /// </summary>
    public Task<List<EventTypeCustomInput>> FindCustomInputs(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputFindManyArgs EventTypeCustomInputFindManyArgs
    );

    /// <summary>
    /// Find multiple Users records for Event Type
    /// </summary>
    public Task<List<User>> FindUsers(
        EventTypeWhereUniqueInput uniqueId,
        UserFindManyArgs UserFindManyArgs
    );

    /// <summary>
    /// Find multiple Webhooks records for Event Type
    /// </summary>
    public Task<List<Webhook>> FindWebhooks(
        EventTypeWhereUniqueInput uniqueId,
        WebhookFindManyArgs WebhookFindManyArgs
    );

    /// <summary>
    /// Find multiple Workflows records for Event Type
    /// </summary>
    public Task<List<WorkflowsOnEventType>> FindWorkflows(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeFindManyArgs WorkflowsOnEventTypeFindManyArgs
    );

    /// <summary>
    /// Get a Destination Calendar record for Event Type
    /// </summary>
    public Task<DestinationCalendar> GetDestinationCalendar(EventTypeWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Hashed Link record for Event Type
    /// </summary>
    public Task<HashedLink> GetHashedLink(EventTypeWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Schedule record for Event Type
    /// </summary>
    public Task<Schedule> GetSchedule(EventTypeWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Team record for Event Type
    /// </summary>
    public Task<Team> GetTeam(EventTypeWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Event Type records
    /// </summary>
    public Task<MetadataDto> EventTypesMeta(EventTypeFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Availability records for Event Type
    /// </summary>
    public Task UpdateAvailability(
        EventTypeWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Update multiple Bookings records for Event Type
    /// </summary>
    public Task UpdateBookings(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Update multiple Custom Inputs records for Event Type
    /// </summary>
    public Task UpdateCustomInputs(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    );

    /// <summary>
    /// Update multiple Users records for Event Type
    /// </summary>
    public Task UpdateUsers(EventTypeWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Update multiple Webhooks records for Event Type
    /// </summary>
    public Task UpdateWebhooks(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Update multiple Workflows records for Event Type
    /// </summary>
    public Task UpdateWorkflows(
        EventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    );

    /// <summary>
    /// Find many EventTypes
    /// </summary>
    public Task<List<EventType>> EventTypes(EventTypeFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Event Type
    /// </summary>
    public Task<EventType> EventType(EventTypeWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Event Type
    /// </summary>
    public Task UpdateEventType(EventTypeWhereUniqueInput uniqueId, EventTypeUpdateInput updateDto);
}
