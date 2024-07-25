using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IVerificationTokensService
{
    /// <summary>
    /// Create one Verification Token
    /// </summary>
    public Task<VerificationToken> CreateVerificationToken(
        VerificationTokenCreateInput verificationtoken
    );

    /// <summary>
    /// Delete one Verification Token
    /// </summary>
    public Task DeleteVerificationToken(VerificationTokenWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many VerificationTokens
    /// </summary>
    public Task<List<VerificationToken>> VerificationTokens(
        VerificationTokenFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one Verification Token
    /// </summary>
    public Task<VerificationToken> VerificationToken(VerificationTokenWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Verification Token
    /// </summary>
    public Task UpdateVerificationToken(
        VerificationTokenWhereUniqueInput uniqueId,
        VerificationTokenUpdateInput updateDto
    );

    /// <summary>
    /// Meta data about Verification Token records
    /// </summary>
    public Task<MetadataDto> VerificationTokensMeta(VerificationTokenFindManyArgs findManyArgs);
}
