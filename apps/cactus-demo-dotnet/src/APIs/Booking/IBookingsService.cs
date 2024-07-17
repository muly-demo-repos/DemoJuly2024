using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IBookingsService
{
    /// <summary>
    /// Connect multiple Attendees records to Booking
    /// </summary>
    public Task ConnectAttendees(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    );

    /// <summary>
    /// Connect multiple Payment records to Booking
    /// </summary>
    public Task ConnectPayment(
        BookingWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Connect multiple References records to Booking
    /// </summary>
    public Task ConnectReferences(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    );

    /// <summary>
    /// Connect multiple Workflow Reminders records to Booking
    /// </summary>
    public Task ConnectWorkflowReminders(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    );

    /// <summary>
    /// Disconnect multiple Attendees records from Booking
    /// </summary>
    public Task DisconnectAttendees(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    );

    /// <summary>
    /// Disconnect multiple Payment records from Booking
    /// </summary>
    public Task DisconnectPayment(
        BookingWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Disconnect multiple References records from Booking
    /// </summary>
    public Task DisconnectReferences(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    );

    /// <summary>
    /// Disconnect multiple Workflow Reminders records from Booking
    /// </summary>
    public Task DisconnectWorkflowReminders(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    );

    /// <summary>
    /// Find multiple Attendees records for Booking
    /// </summary>
    public Task<List<Attendee>> FindAttendees(
        BookingWhereUniqueInput uniqueId,
        AttendeeFindManyArgs AttendeeFindManyArgs
    );

    /// <summary>
    /// Find multiple Payment records for Booking
    /// </summary>
    public Task<List<Payment>> FindPayment(
        BookingWhereUniqueInput uniqueId,
        PaymentFindManyArgs PaymentFindManyArgs
    );

    /// <summary>
    /// Find multiple References records for Booking
    /// </summary>
    public Task<List<BookingReference>> FindReferences(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceFindManyArgs BookingReferenceFindManyArgs
    );

    /// <summary>
    /// Find multiple Workflow Reminders records for Booking
    /// </summary>
    public Task<List<WorkflowReminder>> FindWorkflowReminders(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderFindManyArgs WorkflowReminderFindManyArgs
    );

    /// <summary>
    /// Get a Daily Ref record for Booking
    /// </summary>
    public Task<DailyEventReference> GetDailyRef(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Destination Calendar record for Booking
    /// </summary>
    public Task<DestinationCalendar> GetDestinationCalendar(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Event Type record for Booking
    /// </summary>
    public Task<EventType> GetEventType(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a User record for Booking
    /// </summary>
    public Task<User> GetUser(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Booking records
    /// </summary>
    public Task<MetadataDto> BookingsMeta(BookingFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Attendees records for Booking
    /// </summary>
    public Task UpdateAttendees(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    );

    /// <summary>
    /// Update multiple Payment records for Booking
    /// </summary>
    public Task UpdatePayment(
        BookingWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Update multiple References records for Booking
    /// </summary>
    public Task UpdateReferences(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    );

    /// <summary>
    /// Update multiple Workflow Reminders records for Booking
    /// </summary>
    public Task UpdateWorkflowReminders(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    );

    /// <summary>
    /// Create one Booking
    /// </summary>
    public Task<Booking> CreateBooking(BookingCreateInput booking);

    /// <summary>
    /// Delete one Booking
    /// </summary>
    public Task DeleteBooking(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Bookings
    /// </summary>
    public Task<List<Booking>> Bookings(BookingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Booking
    /// </summary>
    public Task<Booking> Booking(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Booking
    /// </summary>
    public Task UpdateBooking(BookingWhereUniqueInput uniqueId, BookingUpdateInput updateDto);
}
