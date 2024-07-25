using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

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
    /// Get a Users record for Membership
    /// </summary>
    public Task<User> GetUsers(MembershipWhereUniqueInput uniqueId);

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
