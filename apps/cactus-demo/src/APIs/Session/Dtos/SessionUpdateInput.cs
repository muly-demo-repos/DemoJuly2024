namespace CactusDemo.APIs.Dtos;

public class SessionUpdateInput
{
    public string? Id { get; set; }

    public string? SessionToken { get; set; }

    public DateTime? Expires { get; set; }

    public int? Users { get; set; }
}
