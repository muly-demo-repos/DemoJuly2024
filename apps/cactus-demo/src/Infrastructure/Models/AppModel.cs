using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemo.Core.Enums;

namespace CactusDemo.Infrastructure.Models;

[Table("AppModels")]
public class AppModelDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string DirName { get; set; }

    public string? Keys { get; set; }

    [Required()]
    public CategoriesEnum Categories { get; set; } = CategoriesEnum.calendar;

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public List<ApiKeyDbModel>? ApiKey { get; set; } = new List<ApiKeyDbModel>();

    public List<CredentialDbModel>? Credential { get; set; } = new List<CredentialDbModel>();

    public List<WebhookDbModel>? Webhook { get; set; } = new List<WebhookDbModel>();
}
