using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class MembershipCreateInput
{
    public int? Id { get; set; }

    public bool Accepted { get; set; }

    public RoleEnum Role { get; set; }

    public Team Team { get; set; }

    public User Users { get; set; }
}
