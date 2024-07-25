using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class MembershipWhereInput
{
    public int? Id { get; set; }

    public bool? Accepted { get; set; }

    public RoleEnum? Role { get; set; }

    public int? Team { get; set; }

    public int? Users { get; set; }
}
