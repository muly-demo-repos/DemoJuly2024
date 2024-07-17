namespace CactusDemo.APIs.Dtos;

public class ApiKeyCreateInput
{
    public string? Id { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime? LastUsedAt { get; set; }

    public string HashedKey { get; set; }

    public AppModel? AppField { get; set; }

    public User? Users { get; set; }
}
