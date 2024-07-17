using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface ISchedulesService
{
    /// <summary>
    /// Create one Schedule
    /// </summary>
    public Task<Schedule> CreateSchedule(ScheduleCreateInput schedule);

    /// <summary>
    /// Delete one Schedule
    /// </summary>
    public Task DeleteSchedule(ScheduleWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Schedules
    /// </summary>
    public Task<List<Schedule>> Schedules(ScheduleFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Schedule
    /// </summary>
    public Task<Schedule> Schedule(ScheduleWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Availability records to Schedule
    /// </summary>
    public Task ConnectAvailability(
        ScheduleWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Connect multiple Event Type records to Schedule
    /// </summary>
    public Task ConnectEventType(
        ScheduleWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Disconnect multiple Availability records from Schedule
    /// </summary>
    public Task DisconnectAvailability(
        ScheduleWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Disconnect multiple Event Type records from Schedule
    /// </summary>
    public Task DisconnectEventType(
        ScheduleWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Find multiple Availability records for Schedule
    /// </summary>
    public Task<List<Availability>> FindAvailability(
        ScheduleWhereUniqueInput uniqueId,
        AvailabilityFindManyArgs AvailabilityFindManyArgs
    );

    /// <summary>
    /// Find multiple Event Type records for Schedule
    /// </summary>
    public Task<List<EventType>> FindEventType(
        ScheduleWhereUniqueInput uniqueId,
        EventTypeFindManyArgs EventTypeFindManyArgs
    );

    /// <summary>
    /// Get a User record for Schedule
    /// </summary>
    public Task<User> GetUser(ScheduleWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Schedule records
    /// </summary>
    public Task<MetadataDto> SchedulesMeta(ScheduleFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Availability records for Schedule
    /// </summary>
    public Task UpdateAvailability(
        ScheduleWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Update multiple Event Type records for Schedule
    /// </summary>
    public Task UpdateEventType(
        ScheduleWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Update one Schedule
    /// </summary>
    public Task UpdateSchedule(ScheduleWhereUniqueInput uniqueId, ScheduleUpdateInput updateDto);
}
