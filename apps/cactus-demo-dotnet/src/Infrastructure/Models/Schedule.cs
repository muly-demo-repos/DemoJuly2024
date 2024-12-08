using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Schedules")]
public class ScheduleDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel User { get; set; } = null;

    [Required()]
    [StringLength(256)]
    public string Name { get; set; }

    [StringLength(256)]
    public string? TimeZone { get; set; }

    public List<EventTypeDbModel>? EventType { get; set; } = new List<EventTypeDbModel>();

    public List<AvailabilityDbModel>? Availability { get; set; } = new List<AvailabilityDbModel>();
}
