using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class AppModelCreateInput
{
    public string? Id { get; set; }

    public string DirName { get; set; }

    public string? Keys { get; set; }

    public CategoriesEnum Categories { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Credential>? Credentials { get; set; }

    public List<Webhook>? Webhook { get; set; }

    public List<ApiKey>? ApiKey { get; set; }
}
