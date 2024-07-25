using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

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
    /// Connect multiple Event Type records to Team
    /// </summary>
    public Task ConnectEventType(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Connect multiple Membership records to Team
    /// </summary>
    public Task ConnectMembership(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Disconnect multiple Event Type records from Team
    /// </summary>
    public Task DisconnectEventType(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Disconnect multiple Membership records from Team
    /// </summary>
    public Task DisconnectMembership(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Find multiple Event Type records for Team
    /// </summary>
    public Task<List<EventType>> FindEventType(
        TeamWhereUniqueInput uniqueId,
        EventTypeFindManyArgs EventTypeFindManyArgs
    );

    /// <summary>
    /// Find multiple Membership records for Team
    /// </summary>
    public Task<List<Membership>> FindMembership(
        TeamWhereUniqueInput uniqueId,
        MembershipFindManyArgs MembershipFindManyArgs
    );

    /// <summary>
    /// Meta data about Team records
    /// </summary>
    public Task<MetadataDto> TeamsMeta(TeamFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Event Type records for Team
    /// </summary>
    public Task UpdateEventType(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Update multiple Membership records for Team
    /// </summary>
    public Task UpdateMembership(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Update one Team
    /// </summary>
    public Task UpdateTeam(TeamWhereUniqueInput uniqueId, TeamUpdateInput updateDto);
}
