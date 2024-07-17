namespace CactusDemo.APIs.Dtos;

public class ResetPasswordRequestWhereInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Email { get; set; }

    public DateTime? Expires { get; set; }
}
