using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IBookingsService
{
    /// <summary>
    /// Connect multiple Attendee records to Booking
    /// </summary>
    public Task ConnectAttendee(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    );

    /// <summary>
    /// Connect multiple Booking Reference records to Booking
    /// </summary>
    public Task ConnectBookingReference(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    );

    /// <summary>
    /// Connect multiple Payment records to Booking
    /// </summary>
    public Task ConnectPayment(
        BookingWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Connect multiple Workflow Reminder records to Booking
    /// </summary>
    public Task ConnectWorkflowReminder(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    );

    /// <summary>
    /// Disconnect multiple Attendee records from Booking
    /// </summary>
    public Task DisconnectAttendee(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    );

    /// <summary>
    /// Disconnect multiple Booking Reference records from Booking
    /// </summary>
    public Task DisconnectBookingReference(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    );

    /// <summary>
    /// Disconnect multiple Payment records from Booking
    /// </summary>
    public Task DisconnectPayment(
        BookingWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Disconnect multiple Workflow Reminder records from Booking
    /// </summary>
    public Task DisconnectWorkflowReminder(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    );

    /// <summary>
    /// Find multiple Attendee records for Booking
    /// </summary>
    public Task<List<Attendee>> FindAttendee(
        BookingWhereUniqueInput uniqueId,
        AttendeeFindManyArgs AttendeeFindManyArgs
    );

    /// <summary>
    /// Find multiple Booking Reference records for Booking
    /// </summary>
    public Task<List<BookingReference>> FindBookingReference(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceFindManyArgs BookingReferenceFindManyArgs
    );

    /// <summary>
    /// Find multiple Payment records for Booking
    /// </summary>
    public Task<List<Payment>> FindPayment(
        BookingWhereUniqueInput uniqueId,
        PaymentFindManyArgs PaymentFindManyArgs
    );

    /// <summary>
    /// Find multiple Workflow Reminder records for Booking
    /// </summary>
    public Task<List<WorkflowReminder>> FindWorkflowReminder(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderFindManyArgs WorkflowReminderFindManyArgs
    );

    /// <summary>
    /// Get a Daily Event Reference record for Booking
    /// </summary>
    public Task<DailyEventReference> GetDailyEventReference(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Destination Calendar record for Booking
    /// </summary>
    public Task<DestinationCalendar> GetDestinationCalendar(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Event Type record for Booking
    /// </summary>
    public Task<EventType> GetEventType(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Users record for Booking
    /// </summary>
    public Task<User> GetUsers(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Booking records
    /// </summary>
    public Task<MetadataDto> BookingsMeta(BookingFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Attendee records for Booking
    /// </summary>
    public Task UpdateAttendee(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    );

    /// <summary>
    /// Update multiple Booking Reference records for Booking
    /// </summary>
    public Task UpdateBookingReference(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    );

    /// <summary>
    /// Update multiple Payment records for Booking
    /// </summary>
    public Task UpdatePayment(
        BookingWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Update multiple Workflow Reminder records for Booking
    /// </summary>
    public Task UpdateWorkflowReminder(
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
