namespace CactusDemoDotnet.APIs.Dtos;

public class ImpersonationWhereInput
{
    public int? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? ImpersonatedUser { get; set; }

    public int? ImpersonatedBy { get; set; }
}
