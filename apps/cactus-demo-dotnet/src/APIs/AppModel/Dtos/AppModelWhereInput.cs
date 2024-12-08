using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class AppModelWhereInput
{
    public string? Id { get; set; }

    public string? DirName { get; set; }

    public string? Keys { get; set; }

    public CategoriesEnum? Categories { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<int>? Credentials { get; set; }

    public List<string>? Webhook { get; set; }

    public List<string>? ApiKey { get; set; }
}
