using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

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
    /// Get a Users record for Session
    /// </summary>
    public Task<User> GetUsers(SessionWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Session records
    /// </summary>
    public Task<MetadataDto> SessionsMeta(SessionFindManyArgs findManyArgs);

    /// <summary>
    /// Update one Session
    /// </summary>
    public Task UpdateSession(SessionWhereUniqueInput uniqueId, SessionUpdateInput updateDto);
}
