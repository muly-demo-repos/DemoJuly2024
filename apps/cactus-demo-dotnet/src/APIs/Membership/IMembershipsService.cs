using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IMembershipsService
{
    /// <summary>
    /// Create one Membership
    /// </summary>
    public Task<Membership> CreateMembership(MembershipCreateInput membership);

    /// <summary>
    /// Delete one Membership
    /// </summary>
    public Task DeleteMembership(MembershipWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Memberships
    /// </summary>
    public Task<List<Membership>> Memberships(MembershipFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Membership
    /// </summary>
    public Task<Membership> Membership(MembershipWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Team record for Membership
    /// </summary>
    public Task<Team> GetTeam(MembershipWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a User record for Membership
    /// </summary>
    public Task<User> GetUser(MembershipWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Membership records
    /// </summary>
    public Task<MetadataDto> MembershipsMeta(MembershipFindManyArgs findManyArgs);

    /// <summary>
    /// Update one Membership
    /// </summary>
    public Task UpdateMembership(
        MembershipWhereUniqueInput uniqueId,
        MembershipUpdateInput updateDto
    );
}
