using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("SelectedCalendars")]
public class SelectedCalendarDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel User { get; set; } = null;

    [Required()]
    [StringLength(256)]
    public string Integration { get; set; }

    [Required()]
    [StringLength(256)]
    public string ExternalId { get; set; }
}
