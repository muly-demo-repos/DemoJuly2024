namespace CactusDemoDotnet.APIs.Dtos;

public class AccountUpdateInput
{
    public string? Id { get; set; }

    public string? TypeField { get; set; }

    public string? Provider { get; set; }

    public string? ProviderAccountId { get; set; }

    public string? RefreshToken { get; set; }

    public string? AccessToken { get; set; }

    public int? ExpiresAt { get; set; }

    public string? TokenType { get; set; }

    public string? Scope { get; set; }

    public string? IdToken { get; set; }

    public string? SessionState { get; set; }

    public int? User { get; set; }
}
