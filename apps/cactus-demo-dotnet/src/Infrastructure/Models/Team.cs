using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Teams")]
public class TeamDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [StringLength(256)]
    public string? Name { get; set; }

    [StringLength(256)]
    public string? Slug { get; set; }

    [StringLength(256)]
    public string? Logo { get; set; }

    [StringLength(256)]
    public string? Bio { get; set; }

    [Required()]
    public bool HideBranding { get; set; }

    public List<EventTypeDbModel>? EventTypes { get; set; } = new List<EventTypeDbModel>();

    public List<MembershipDbModel>? Members { get; set; } = new List<MembershipDbModel>();
}
