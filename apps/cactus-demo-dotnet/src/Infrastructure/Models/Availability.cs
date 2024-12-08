using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Availabilities")]
public class AvailabilityDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    public int? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    public int? EventTypeId { get; set; }

    [ForeignKey(nameof(EventTypeId))]
    public EventTypeDbModel? EventType { get; set; } = null;

    [Required()]
    [Range(0, 99999999999)]
    public int Days { get; set; }

    [Required()]
    public DateTime StartTime { get; set; }

    [Required()]
    public DateTime EndTime { get; set; }

    public DateTime? Date { get; set; }

    public int? ScheduleId { get; set; }

    [ForeignKey(nameof(ScheduleId))]
    public ScheduleDbModel? Schedule { get; set; } = null;
}
