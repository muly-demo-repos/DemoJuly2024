using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class VerificationTokensExtensions
{
    public static VerificationToken ToDto(this VerificationTokenDbModel model)
    {
        return new VerificationToken
        {
            Id = model.Id,
            Identifier = model.Identifier,
            Token = model.Token,
            Expires = model.Expires,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static VerificationTokenDbModel ToModel(
        this VerificationTokenUpdateInput updateDto,
        VerificationTokenWhereUniqueInput uniqueId
    )
    {
        var verificationToken = new VerificationTokenDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.Identifier != null)
        {
            verificationToken.Identifier = updateDto.Identifier;
        }
        if (updateDto.Token != null)
        {
            verificationToken.Token = updateDto.Token;
        }
        if (updateDto.Expires != null)
        {
            verificationToken.Expires = updateDto.Expires.Value;
        }
        if (updateDto.CreatedAt != null)
        {
            verificationToken.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            verificationToken.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return verificationToken;
    }
}
