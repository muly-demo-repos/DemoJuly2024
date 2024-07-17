using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class ImpersonationsExtensions
{
    public static Impersonation ToDto(this ImpersonationDbModel model)
    {
        return new Impersonation
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            ImpersonatedUser = model.ImpersonatedUserId,
            ImpersonatedBy = model.ImpersonatedById,
        };
    }

    public static ImpersonationDbModel ToModel(
        this ImpersonationUpdateInput updateDto,
        ImpersonationWhereUniqueInput uniqueId
    )
    {
        var impersonation = new ImpersonationDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            impersonation.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.ImpersonatedUser != null)
        {
            impersonation.ImpersonatedUser = updateDto.ImpersonatedUser.Value;
        }
        if (updateDto.ImpersonatedBy != null)
        {
            impersonation.ImpersonatedBy = updateDto.ImpersonatedBy.Value;
        }

        return impersonation;
    }
}
