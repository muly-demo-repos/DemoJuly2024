using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class ResetPasswordRequestsExtensions
{
    public static ResetPasswordRequest ToDto(this ResetPasswordRequestDbModel model)
    {
        return new ResetPasswordRequest
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Email = model.Email,
            Expires = model.Expires,
        };
    }

    public static ResetPasswordRequestDbModel ToModel(
        this ResetPasswordRequestUpdateInput updateDto,
        ResetPasswordRequestWhereUniqueInput uniqueId
    )
    {
        var resetPasswordRequest = new ResetPasswordRequestDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            resetPasswordRequest.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            resetPasswordRequest.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Email != null)
        {
            resetPasswordRequest.Email = updateDto.Email;
        }
        if (updateDto.Expires != null)
        {
            resetPasswordRequest.Expires = updateDto.Expires.Value;
        }

        return resetPasswordRequest;
    }
}
