using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface ISessionsService
{
    /// <summary>
    /// Create one Session
    /// </summary>
    public Task<Session> CreateSession(SessionCreateInput session);

    /// <summary>
    /// Delete one Session
    /// </summary>
    public Task DeleteSession(SessionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Sessions
    /// </summary>
    public Task<List<Session>> Sessions(SessionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Session
    /// </summary>
    public Task<Session> Session(SessionWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a User record for Session
    /// </summary>
    public Task<User> GetUser(SessionWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Session records
    /// </summary>
    public Task<MetadataDto> SessionsMeta(SessionFindManyArgs findManyArgs);

    /// <summary>
    /// Update one Session
    /// </summary>
    public Task UpdateSession(SessionWhereUniqueInput uniqueId, SessionUpdateInput updateDto);
}
