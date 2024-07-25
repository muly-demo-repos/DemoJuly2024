using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class MembershipsExtensions
{
    public static Membership ToDto(this MembershipDbModel model)
    {
        return new Membership
        {
            Id = model.Id,
            Accepted = model.Accepted,
            Role = model.Role,
            Team = model.TeamId,
            Users = model.UsersId,
        };
    }

    public static MembershipDbModel ToModel(
        this MembershipUpdateInput updateDto,
        MembershipWhereUniqueInput uniqueId
    )
    {
        var membership = new MembershipDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.Accepted != null)
        {
            membership.Accepted = updateDto.Accepted.Value;
        }
        if (updateDto.Role != null)
        {
            membership.Role = updateDto.Role.Value;
        }
        if (updateDto.Team != null)
        {
            membership.Team = updateDto.Team.Value;
        }
        if (updateDto.Users != null)
        {
            membership.Users = updateDto.Users.Value;
        }

        return membership;
    }
}
