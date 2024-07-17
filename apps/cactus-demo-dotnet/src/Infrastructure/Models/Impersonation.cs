using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Impersonations")]
public class ImpersonationDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public int ImpersonatedUserId { get; set; }

    [ForeignKey(nameof(ImpersonatedUserId))]
    public UserDbModel ImpersonatedUser { get; set; } = null;

    public int ImpersonatedById { get; set; }

    [ForeignKey(nameof(ImpersonatedById))]
    public UserDbModel ImpersonatedBy { get; set; } = null;
}
