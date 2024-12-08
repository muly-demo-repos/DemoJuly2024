using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IAttendeesService
{
    /// <summary>
    /// Get a Booking record for Attendee
    /// </summary>
    public Task<Booking> GetBooking(AttendeeWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Attendee records
    /// </summary>
    public Task<MetadataDto> AttendeesMeta(AttendeeFindManyArgs findManyArgs);

    /// <summary>
    /// Create one Attendee
    /// </summary>
    public Task<Attendee> CreateAttendee(AttendeeCreateInput attendee);

    /// <summary>
    /// Delete one Attendee
    /// </summary>
    public Task DeleteAttendee(AttendeeWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Attendees
    /// </summary>
    public Task<List<Attendee>> Attendees(AttendeeFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Attendee
    /// </summary>
    public Task<Attendee> Attendee(AttendeeWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Attendee
    /// </summary>
    public Task UpdateAttendee(AttendeeWhereUniqueInput uniqueId, AttendeeUpdateInput updateDto);
}
