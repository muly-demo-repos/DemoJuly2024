using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class SessionsExtensions
{
    public static Session ToDto(this SessionDbModel model)
    {
        return new Session
        {
            Id = model.Id,
            SessionToken = model.SessionToken,
            Expires = model.Expires,
            User = model.UserId,
        };
    }

    public static SessionDbModel ToModel(
        this SessionUpdateInput updateDto,
        SessionWhereUniqueInput uniqueId
    )
    {
        var session = new SessionDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.SessionToken != null)
        {
            session.SessionToken = updateDto.SessionToken;
        }
        if (updateDto.Expires != null)
        {
            session.Expires = updateDto.Expires.Value;
        }

        return session;
    }
}
