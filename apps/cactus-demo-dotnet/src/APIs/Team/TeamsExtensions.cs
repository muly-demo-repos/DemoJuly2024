using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class TeamsExtensions
{
    public static Team ToDto(this TeamDbModel model)
    {
        return new Team
        {
            Id = model.Id,
            Name = model.Name,
            Slug = model.Slug,
            Logo = model.Logo,
            Bio = model.Bio,
            HideBranding = model.HideBranding,
            EventTypes = model.EventTypes?.Select(x => x.Id).ToList(),
            Members = model.Members?.Select(x => x.Id).ToList(),
        };
    }

    public static TeamDbModel ToModel(this TeamUpdateInput updateDto, TeamWhereUniqueInput uniqueId)
    {
        var team = new TeamDbModel
        {
            Id = uniqueId.Id,
            Name = updateDto.Name,
            Slug = updateDto.Slug,
            Logo = updateDto.Logo,
            Bio = updateDto.Bio
        };

        // map required fields
        if (updateDto.HideBranding != null)
        {
            team.HideBranding = updateDto.HideBranding.Value;
        }

        return team;
    }
}
