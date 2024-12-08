using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IResetPasswordRequestsService
{
    /// <summary>
    /// Create one Reset Password Request
    /// </summary>
    public Task<ResetPasswordRequest> CreateResetPasswordRequest(
        ResetPasswordRequestCreateInput resetpasswordrequest
    );

    /// <summary>
    /// Delete one Reset Password Request
    /// </summary>
    public Task DeleteResetPasswordRequest(ResetPasswordRequestWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ResetPasswordRequests
    /// </summary>
    public Task<List<ResetPasswordRequest>> ResetPasswordRequests(
        ResetPasswordRequestFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one Reset Password Request
    /// </summary>
    public Task<ResetPasswordRequest> ResetPasswordRequest(
        ResetPasswordRequestWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Meta data about Reset Password Request records
    /// </summary>
    public Task<MetadataDto> ResetPasswordRequestsMeta(
        ResetPasswordRequestFindManyArgs findManyArgs
    );

    /// <summary>
    /// Update one Reset Password Request
    /// </summary>
    public Task UpdateResetPasswordRequest(
        ResetPasswordRequestWhereUniqueInput uniqueId,
        ResetPasswordRequestUpdateInput updateDto
    );
}
