using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemo.Infrastructure.Models;

[Table("Impersonations")]
public class ImpersonationDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public int UsersImpersonationsImpersonatedByIdTousersId { get; set; }

    [ForeignKey(nameof(UsersImpersonationsImpersonatedByIdTousersId))]
    public UserDbModel UsersImpersonationsImpersonatedByIdTousers { get; set; } = null;

    public int UsersImpersonationsImpersonatedUserIdTousersId { get; set; }

    [ForeignKey(nameof(UsersImpersonationsImpersonatedUserIdTousersId))]
    public UserDbModel UsersImpersonationsImpersonatedUserIdTousers { get; set; } = null;
}
