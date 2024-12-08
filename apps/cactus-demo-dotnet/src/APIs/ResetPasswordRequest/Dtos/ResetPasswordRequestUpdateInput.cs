namespace CactusDemoDotnet.APIs.Dtos;

public class ResetPasswordRequestUpdateInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Email { get; set; }

    public DateTime? Expires { get; set; }
}
