namespace CactusDemoDotnet.APIs.Dtos;

public class Impersonation
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public int ImpersonatedUser { get; set; }

    public int ImpersonatedBy { get; set; }
}
