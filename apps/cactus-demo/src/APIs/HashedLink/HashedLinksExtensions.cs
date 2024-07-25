using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class HashedLinksExtensions
{
    public static HashedLink ToDto(this HashedLinkDbModel model)
    {
        return new HashedLink
        {
            Id = model.Id,
            Link = model.Link,
            EventType = model.EventTypeId,
        };
    }

    public static HashedLinkDbModel ToModel(
        this HashedLinkUpdateInput updateDto,
        HashedLinkWhereUniqueInput uniqueId
    )
    {
        var hashedLink = new HashedLinkDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.Link != null)
        {
            hashedLink.Link = updateDto.Link;
        }
        if (updateDto.EventType != null)
        {
            hashedLink.EventType = updateDto.EventType.Value;
        }

        return hashedLink;
    }
}
