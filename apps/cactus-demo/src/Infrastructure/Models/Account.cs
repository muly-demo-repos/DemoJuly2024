using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemo.Infrastructure.Models;

[Table("Accounts")]
public class AccountDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string TypeField { get; set; }

    [Required()]
    [StringLength(256)]
    public string Provider { get; set; }

    [Required()]
    [StringLength(256)]
    public string ProviderAccountId { get; set; }

    [StringLength(256)]
    public string? RefreshToken { get; set; }

    [StringLength(256)]
    public string? AccessToken { get; set; }

    [Range(0, 99999999999)]
    public int? ExpiresAt { get; set; }

    [StringLength(256)]
    public string? TokenType { get; set; }

    [StringLength(256)]
    public string? Scope { get; set; }

    [StringLength(256)]
    public string? IdToken { get; set; }

    [StringLength(256)]
    public string? SessionState { get; set; }

    public int? UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel? Users { get; set; } = null;
}
