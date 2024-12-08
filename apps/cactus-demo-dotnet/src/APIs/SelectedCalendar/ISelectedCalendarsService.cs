using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface ISelectedCalendarsService
{
    /// <summary>
    /// Create one Selected Calendar
    /// </summary>
    public Task<SelectedCalendar> CreateSelectedCalendar(
        SelectedCalendarCreateInput selectedcalendar
    );

    /// <summary>
    /// Delete one Selected Calendar
    /// </summary>
    public Task DeleteSelectedCalendar(SelectedCalendarWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many SelectedCalendars
    /// </summary>
    public Task<List<SelectedCalendar>> SelectedCalendars(
        SelectedCalendarFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one Selected Calendar
    /// </summary>
    public Task<SelectedCalendar> SelectedCalendar(SelectedCalendarWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a User record for Selected Calendar
    /// </summary>
    public Task<User> GetUser(SelectedCalendarWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Selected Calendar records
    /// </summary>
    public Task<MetadataDto> SelectedCalendarsMeta(SelectedCalendarFindManyArgs findManyArgs);

    /// <summary>
    /// Update one Selected Calendar
    /// </summary>
    public Task UpdateSelectedCalendar(
        SelectedCalendarWhereUniqueInput uniqueId,
        SelectedCalendarUpdateInput updateDto
    );
}
