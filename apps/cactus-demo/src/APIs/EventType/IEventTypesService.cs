using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

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
    /// Connect multiple Booking records to Event Type
    /// </summary>
    public Task ConnectBooking(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Connect multiple Event Type Custom Input records to Event Type
    /// </summary>
    public Task ConnectEventTypeCustomInput(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    );

    /// <summary>
    /// Connect multiple Users records to Event Type
    /// </summary>
    public Task ConnectUsers(EventTypeWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Connect multiple Webhook records to Event Type
    /// </summary>
    public Task ConnectWebhook(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Connect multiple Workflows On Event Types records to Event Type
    /// </summary>
    public Task ConnectWorkflowsOnEventTypes(
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
    /// Disconnect multiple Booking records from Event Type
    /// </summary>
    public Task DisconnectBooking(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Disconnect multiple Event Type Custom Input records from Event Type
    /// </summary>
    public Task DisconnectEventTypeCustomInput(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    );

    /// <summary>
    /// Disconnect multiple Users records from Event Type
    /// </summary>
    public Task DisconnectUsers(EventTypeWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Disconnect multiple Webhook records from Event Type
    /// </summary>
    public Task DisconnectWebhook(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Disconnect multiple Workflows On Event Types records from Event Type
    /// </summary>
    public Task DisconnectWorkflowsOnEventTypes(
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
    /// Find multiple Booking records for Event Type
    /// </summary>
    public Task<List<Booking>> FindBooking(
        EventTypeWhereUniqueInput uniqueId,
        BookingFindManyArgs BookingFindManyArgs
    );

    /// <summary>
    /// Find multiple Event Type Custom Input records for Event Type
    /// </summary>
    public Task<List<EventTypeCustomInput>> FindEventTypeCustomInput(
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
    /// Find multiple Webhook records for Event Type
    /// </summary>
    public Task<List<Webhook>> FindWebhook(
        EventTypeWhereUniqueInput uniqueId,
        WebhookFindManyArgs WebhookFindManyArgs
    );

    /// <summary>
    /// Find multiple Workflows On Event Types records for Event Type
    /// </summary>
    public Task<List<WorkflowsOnEventType>> FindWorkflowsOnEventTypes(
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
    /// Update multiple Booking records for Event Type
    /// </summary>
    public Task UpdateBooking(
        EventTypeWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Update multiple Event Type Custom Input records for Event Type
    /// </summary>
    public Task UpdateEventTypeCustomInput(
        EventTypeWhereUniqueInput uniqueId,
        EventTypeCustomInputWhereUniqueInput[] eventTypeCustomInputsId
    );

    /// <summary>
    /// Update multiple Users records for Event Type
    /// </summary>
    public Task UpdateUsers(EventTypeWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Update multiple Webhook records for Event Type
    /// </summary>
    public Task UpdateWebhook(
        EventTypeWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Update multiple Workflows On Event Types records for Event Type
    /// </summary>
    public Task UpdateWorkflowsOnEventTypes(
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
