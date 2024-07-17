namespace CactusDemoDotnet.APIs.Dtos;

public class ApiKey
{
    public string Id { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime? LastUsedAt { get; set; }

    public string HashedKey { get; set; }

    public int? User { get; set; }

    public string? AppField { get; set; }
}
