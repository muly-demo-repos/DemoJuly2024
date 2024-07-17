namespace CactusDemoDotnet.APIs.Dtos;

public class ImpersonationCreateInput
{
    public int? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public User ImpersonatedUser { get; set; }

    public User ImpersonatedBy { get; set; }
}
