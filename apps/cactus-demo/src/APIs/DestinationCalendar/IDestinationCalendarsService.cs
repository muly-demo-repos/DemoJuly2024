using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IDestinationCalendarsService
{
    /// <summary>
    /// Create one Destination Calendar
    /// </summary>
    public Task<DestinationCalendar> CreateDestinationCalendar(
        DestinationCalendarCreateInput destinationcalendar
    );

    /// <summary>
    /// Delete one Destination Calendar
    /// </summary>
    public Task DeleteDestinationCalendar(DestinationCalendarWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Booking record for Destination Calendar
    /// </summary>
    public Task<Booking> GetBooking(DestinationCalendarWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Credential record for Destination Calendar
    /// </summary>
    public Task<Credential> GetCredential(DestinationCalendarWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Event Type record for Destination Calendar
    /// </summary>
    public Task<EventType> GetEventType(DestinationCalendarWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Users record for Destination Calendar
    /// </summary>
    public Task<User> GetUsers(DestinationCalendarWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Destination Calendar records
    /// </summary>
    public Task<MetadataDto> DestinationCalendarsMeta(DestinationCalendarFindManyArgs findManyArgs);

    /// <summary>
    /// Find many DestinationCalendars
    /// </summary>
    public Task<List<DestinationCalendar>> DestinationCalendars(
        DestinationCalendarFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one Destination Calendar
    /// </summary>
    public Task<DestinationCalendar> DestinationCalendar(
        DestinationCalendarWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one Destination Calendar
    /// </summary>
    public Task UpdateDestinationCalendar(
        DestinationCalendarWhereUniqueInput uniqueId,
        DestinationCalendarUpdateInput updateDto
    );
}
