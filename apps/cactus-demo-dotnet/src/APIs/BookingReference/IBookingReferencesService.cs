using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IBookingReferencesService
{
    /// <summary>
    /// Get a Booking record for Booking Reference
    /// </summary>
    public Task<Booking> GetBooking(BookingReferenceWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Booking Reference records
    /// </summary>
    public Task<MetadataDto> BookingReferencesMeta(BookingReferenceFindManyArgs findManyArgs);

    /// <summary>
    /// Create one Booking Reference
    /// </summary>
    public Task<BookingReference> CreateBookingReference(
        BookingReferenceCreateInput bookingreference
    );

    /// <summary>
    /// Delete one Booking Reference
    /// </summary>
    public Task DeleteBookingReference(BookingReferenceWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many BookingReferences
    /// </summary>
    public Task<List<BookingReference>> BookingReferences(
        BookingReferenceFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one Booking Reference
    /// </summary>
    public Task<BookingReference> BookingReference(BookingReferenceWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Booking Reference
    /// </summary>
    public Task UpdateBookingReference(
        BookingReferenceWhereUniqueInput uniqueId,
        BookingReferenceUpdateInput updateDto
    );
}
