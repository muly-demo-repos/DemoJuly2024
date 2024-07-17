using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class ImpersonationsExtensions
{
    public static Impersonation ToDto(this ImpersonationDbModel model)
    {
        return new Impersonation
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UsersImpersonationsImpersonatedByIdTousers =
                model.UsersImpersonationsImpersonatedByIdTousersId,
            UsersImpersonationsImpersonatedUserIdTousers =
                model.UsersImpersonationsImpersonatedUserIdTousersId,
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
        if (updateDto.UsersImpersonationsImpersonatedByIdTousers != null)
        {
            impersonation.UsersImpersonationsImpersonatedByIdTousers = updateDto
                .UsersImpersonationsImpersonatedByIdTousers
                .Value;
        }
        if (updateDto.UsersImpersonationsImpersonatedUserIdTousers != null)
        {
            impersonation.UsersImpersonationsImpersonatedUserIdTousers = updateDto
                .UsersImpersonationsImpersonatedUserIdTousers
                .Value;
        }

        return impersonation;
    }
}
