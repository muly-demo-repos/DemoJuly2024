using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("ReminderMails")]
public class ReminderMailDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int ReferenceId { get; set; }

    [Required()]
    public ReminderTypeEnum ReminderType { get; set; } =
        ReminderTypeEnum.PENDING_BOOKING_CONFIRMATION;

    [Required()]
    [Range(0, 99999999999)]
    public int ElapsedMinutes { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }
}
