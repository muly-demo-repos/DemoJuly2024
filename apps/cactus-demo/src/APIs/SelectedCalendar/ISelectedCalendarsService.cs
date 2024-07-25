using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

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
    /// Get a Users record for Selected Calendar
    /// </summary>
    public Task<User> GetUsers(SelectedCalendarWhereUniqueInput uniqueId);

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
