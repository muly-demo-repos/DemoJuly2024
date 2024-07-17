using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class ApiKeysExtensions
{
    public static ApiKey ToDto(this ApiKeyDbModel model)
    {
        return new ApiKey
        {
            Id = model.Id,
            Note = model.Note,
            CreatedAt = model.CreatedAt,
            ExpiresAt = model.ExpiresAt,
            LastUsedAt = model.LastUsedAt,
            HashedKey = model.HashedKey,
            AppField = model.AppFieldId,
            Users = model.UsersId,
        };
    }

    public static ApiKeyDbModel ToModel(
        this ApiKeyUpdateInput updateDto,
        ApiKeyWhereUniqueInput uniqueId
    )
    {
        var apiKey = new ApiKeyDbModel
        {
            Id = uniqueId.Id,
            Note = updateDto.Note,
            ExpiresAt = updateDto.ExpiresAt,
            LastUsedAt = updateDto.LastUsedAt
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            apiKey.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.HashedKey != null)
        {
            apiKey.HashedKey = updateDto.HashedKey;
        }

        return apiKey;
    }
}
