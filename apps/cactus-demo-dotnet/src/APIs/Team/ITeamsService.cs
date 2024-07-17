using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface ITeamsService
{
    /// <summary>
    /// Create one Team
    /// </summary>
    public Task<Team> CreateTeam(TeamCreateInput team);

    /// <summary>
    /// Delete one Team
    /// </summary>
    public Task DeleteTeam(TeamWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Teams
    /// </summary>
    public Task<List<Team>> Teams(TeamFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Team
    /// </summary>
    public Task<Team> Team(TeamWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Event Types records to Team
    /// </summary>
    public Task ConnectEventTypes(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Connect multiple Members records to Team
    /// </summary>
    public Task ConnectMembers(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Disconnect multiple Event Types records from Team
    /// </summary>
    public Task DisconnectEventTypes(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Disconnect multiple Members records from Team
    /// </summary>
    public Task DisconnectMembers(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Find multiple Event Types records for Team
    /// </summary>
    public Task<List<EventType>> FindEventTypes(
        TeamWhereUniqueInput uniqueId,
        EventTypeFindManyArgs EventTypeFindManyArgs
    );

    /// <summary>
    /// Find multiple Members records for Team
    /// </summary>
    public Task<List<Membership>> FindMembers(
        TeamWhereUniqueInput uniqueId,
        MembershipFindManyArgs MembershipFindManyArgs
    );

    /// <summary>
    /// Meta data about Team records
    /// </summary>
    public Task<MetadataDto> TeamsMeta(TeamFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Event Types records for Team
    /// </summary>
    public Task UpdateEventTypes(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Update multiple Members records for Team
    /// </summary>
    public Task UpdateMembers(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Update one Team
    /// </summary>
    public Task UpdateTeam(TeamWhereUniqueInput uniqueId, TeamUpdateInput updateDto);
}
