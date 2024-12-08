using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IImpersonationsService
{
    /// <summary>
    /// Create one Impersonation
    /// </summary>
    public Task<Impersonation> CreateImpersonation(ImpersonationCreateInput impersonation);

    /// <summary>
    /// Delete one Impersonation
    /// </summary>
    public Task DeleteImpersonation(ImpersonationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Impersonations
    /// </summary>
    public Task<List<Impersonation>> Impersonations(ImpersonationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Impersonation
    /// </summary>
    public Task<Impersonation> Impersonation(ImpersonationWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Impersonated By record for Impersonation
    /// </summary>
    public Task<User> GetImpersonatedBy(ImpersonationWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Impersonated User record for Impersonation
    /// </summary>
    public Task<User> GetImpersonatedUser(ImpersonationWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Impersonation records
    /// </summary>
    public Task<MetadataDto> ImpersonationsMeta(ImpersonationFindManyArgs findManyArgs);

    /// <summary>
    /// Update one Impersonation
    /// </summary>
    public Task UpdateImpersonation(
        ImpersonationWhereUniqueInput uniqueId,
        ImpersonationUpdateInput updateDto
    );
}
