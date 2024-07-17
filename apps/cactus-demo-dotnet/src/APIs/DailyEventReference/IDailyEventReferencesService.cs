using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IDailyEventReferencesService
{
    /// <summary>
    /// Create one Daily Event Reference
    /// </summary>
    public Task<DailyEventReference> CreateDailyEventReference(
        DailyEventReferenceCreateInput dailyeventreference
    );

    /// <summary>
    /// Get a Booking record for Daily Event Reference
    /// </summary>
    public Task<Booking> GetBooking(DailyEventReferenceWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Daily Event Reference records
    /// </summary>
    public Task<MetadataDto> DailyEventReferencesMeta(DailyEventReferenceFindManyArgs findManyArgs);

    /// <summary>
    /// Delete one Daily Event Reference
    /// </summary>
    public Task DeleteDailyEventReference(DailyEventReferenceWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many DailyEventReferences
    /// </summary>
    public Task<List<DailyEventReference>> DailyEventReferences(
        DailyEventReferenceFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one Daily Event Reference
    /// </summary>
    public Task<DailyEventReference> DailyEventReference(
        DailyEventReferenceWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one Daily Event Reference
    /// </summary>
    public Task UpdateDailyEventReference(
        DailyEventReferenceWhereUniqueInput uniqueId,
        DailyEventReferenceUpdateInput updateDto
    );
}
