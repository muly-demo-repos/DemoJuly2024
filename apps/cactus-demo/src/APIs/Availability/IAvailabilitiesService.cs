using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IAvailabilitiesService
{
    /// <summary>
    /// Meta data about Availability records
    /// </summary>
    public Task<MetadataDto> AvailabilitiesMeta(AvailabilityFindManyArgs findManyArgs);

    /// <summary>
    /// Get a Event Type record for Availability
    /// </summary>
    public Task<EventType> GetEventType(AvailabilityWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Schedule record for Availability
    /// </summary>
    public Task<Schedule> GetSchedule(AvailabilityWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Users record for Availability
    /// </summary>
    public Task<User> GetUsers(AvailabilityWhereUniqueInput uniqueId);

    /// <summary>
    /// Create one Availability
    /// </summary>
    public Task<Availability> CreateAvailability(AvailabilityCreateInput availability);

    /// <summary>
    /// Delete one Availability
    /// </summary>
    public Task DeleteAvailability(AvailabilityWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Availabilities
    /// </summary>
    public Task<List<Availability>> Availabilities(AvailabilityFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Availability
    /// </summary>
    public Task<Availability> Availability(AvailabilityWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Availability
    /// </summary>
    public Task UpdateAvailability(
        AvailabilityWhereUniqueInput uniqueId,
        AvailabilityUpdateInput updateDto
    );
}
