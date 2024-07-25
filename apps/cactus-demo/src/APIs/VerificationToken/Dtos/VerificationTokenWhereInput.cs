namespace CactusDemo.APIs.Dtos;

public class VerificationTokenWhereInput
{
    public int? Id { get; set; }

    public string? Identifier { get; set; }

    public string? Token { get; set; }

    public DateTime? Expires { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
