using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Bookings")]
public class BookingDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string Uid { get; set; }

    public int? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    public int? EventTypeId { get; set; }

    [ForeignKey(nameof(EventTypeId))]
    public EventTypeDbModel? EventType { get; set; } = null;

    [Required()]
    [StringLength(256)]
    public string Title { get; set; }

    [StringLength(256)]
    public string? Description { get; set; }

    public string? CustomInputs { get; set; }

    [Required()]
    public DateTime StartTime { get; set; }

    [Required()]
    public DateTime EndTime { get; set; }

    [StringLength(256)]
    public string? Location { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Required()]
    public StatusEnum Status { get; set; } = StatusEnum.CANCELLED;

    [Required()]
    public bool Paid { get; set; }

    [StringLength(256)]
    public string? CancellationReason { get; set; }

    [StringLength(256)]
    public string? RejectionReason { get; set; }

    [StringLength(256)]
    public string? DynamicEventSlugRef { get; set; }

    [StringLength(256)]
    public string? DynamicGroupSlugRef { get; set; }

    public bool? Rescheduled { get; set; }

    [StringLength(256)]
    public string? FromReschedule { get; set; }

    [StringLength(256)]
    public string? RecurringEventId { get; set; }

    [StringLength(256)]
    public string? SmsReminderNumber { get; set; }

    public DestinationCalendarDbModel? DestinationCalendar { get; set; } = null;

    public List<BookingReferenceDbModel>? References { get; set; } =
        new List<BookingReferenceDbModel>();

    public List<AttendeeDbModel>? Attendees { get; set; } = new List<AttendeeDbModel>();

    public DailyEventReferenceDbModel? DailyRef { get; set; } = null;

    public List<PaymentDbModel>? Payment { get; set; } = new List<PaymentDbModel>();

    public List<WorkflowReminderDbModel>? WorkflowReminders { get; set; } =
        new List<WorkflowReminderDbModel>();
}
