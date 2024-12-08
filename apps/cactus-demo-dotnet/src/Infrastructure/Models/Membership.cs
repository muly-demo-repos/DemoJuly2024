using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Memberships")]
public class MembershipDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    public bool Accepted { get; set; }

    [Required()]
    public RoleEnum Role { get; set; } = RoleEnum.MEMBER;

    public int TeamId { get; set; }

    [ForeignKey(nameof(TeamId))]
    public TeamDbModel Team { get; set; } = null;

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel User { get; set; } = null;
}
