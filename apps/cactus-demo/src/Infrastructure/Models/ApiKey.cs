using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemo.Infrastructure.Models;

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

    public string? AppFieldId { get; set; }

    [ForeignKey(nameof(AppFieldId))]
    public AppModelDbModel? AppField { get; set; } = null;

    public int? UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel? Users { get; set; } = null;
}
