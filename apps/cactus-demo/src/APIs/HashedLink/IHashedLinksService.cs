using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IHashedLinksService
{
    /// <summary>
    /// Create one Hashed Link
    /// </summary>
    public Task<HashedLink> CreateHashedLink(HashedLinkCreateInput hashedlink);

    /// <summary>
    /// Delete one Hashed Link
    /// </summary>
    public Task DeleteHashedLink(HashedLinkWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many HashedLinks
    /// </summary>
    public Task<List<HashedLink>> HashedLinks(HashedLinkFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Hashed Link
    /// </summary>
    public Task<HashedLink> HashedLink(HashedLinkWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Event Type record for Hashed Link
    /// </summary>
    public Task<EventType> GetEventType(HashedLinkWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Hashed Link records
    /// </summary>
    public Task<MetadataDto> HashedLinksMeta(HashedLinkFindManyArgs findManyArgs);

    /// <summary>
    /// Update one Hashed Link
    /// </summary>
    public Task UpdateHashedLink(
        HashedLinkWhereUniqueInput uniqueId,
        HashedLinkUpdateInput updateDto
    );
}
