using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class AppModelCreateInput
{
    public string? Id { get; set; }

    public string DirName { get; set; }

    public string? Keys { get; set; }

    public CategoriesEnum Categories { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<ApiKey>? ApiKey { get; set; }

    public List<Credential>? Credential { get; set; }

    public List<Webhook>? Webhook { get; set; }
}
