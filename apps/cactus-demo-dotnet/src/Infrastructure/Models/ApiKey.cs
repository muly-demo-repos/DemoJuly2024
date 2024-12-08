using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("ApiKeys")]
public class ApiKeyDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(256)]
    public string? Note { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime? LastUsedAt { get; set; }

    [Required()]
    [StringLength(256)]
    public string HashedKey { get; set; }

    public int? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    public string? AppFieldId { get; set; }

    [ForeignKey(nameof(AppFieldId))]
    public AppModelDbModel? AppField { get; set; } = null;
}
