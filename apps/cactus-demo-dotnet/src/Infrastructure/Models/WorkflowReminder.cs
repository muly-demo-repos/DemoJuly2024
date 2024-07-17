using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("WorkflowReminders")]
public class WorkflowReminderDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    public int? BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public BookingDbModel? Booking { get; set; } = null;

    [Required()]
    public MethodEnum Method { get; set; } = MethodEnum.EMAIL;

    [Required()]
    public DateTime ScheduledDate { get; set; }

    [StringLength(256)]
    public string? ReferenceId { get; set; }

    [Required()]
    public bool Scheduled { get; set; }

    public int WorkflowStepId { get; set; }

    [ForeignKey(nameof(WorkflowStepId))]
    public WorkflowStepDbModel WorkflowStep { get; set; } = null;
}
