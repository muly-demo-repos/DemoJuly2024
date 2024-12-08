using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class Membership
{
    public int Id { get; set; }

    public bool Accepted { get; set; }

    public RoleEnum Role { get; set; }

    public int Team { get; set; }

    public int User { get; set; }
}
