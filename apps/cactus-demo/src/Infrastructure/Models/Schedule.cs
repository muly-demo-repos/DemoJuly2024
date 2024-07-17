using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemo.Infrastructure.Models;

[Table("Schedules")]
public class ScheduleDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string Name { get; set; }

    [StringLength(256)]
    public string? TimeZone { get; set; }

    public int UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel Users { get; set; } = null;

    public List<AvailabilityDbModel>? Availability { get; set; } = new List<AvailabilityDbModel>();

    public List<EventTypeDbModel>? EventType { get; set; } = new List<EventTypeDbModel>();
}
