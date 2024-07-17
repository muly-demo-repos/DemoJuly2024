using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemo.Core.Enums;

namespace CactusDemo.Infrastructure.Models;

[Table("Bookings")]
public class BookingDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string Uid { get; set; }

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

    public int? EventTypeId { get; set; }

    [ForeignKey(nameof(EventTypeId))]
    public EventTypeDbModel? EventType { get; set; } = null;

    public int? UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel? Users { get; set; } = null;

    public List<AttendeeDbModel>? Attendee { get; set; } = new List<AttendeeDbModel>();

    public List<BookingReferenceDbModel>? BookingReference { get; set; } =
        new List<BookingReferenceDbModel>();

    public DailyEventReferenceDbModel? DailyEventReference { get; set; } = null;

    public DestinationCalendarDbModel? DestinationCalendar { get; set; } = null;

    public List<PaymentDbModel>? Payment { get; set; } = new List<PaymentDbModel>();

    public List<WorkflowReminderDbModel>? WorkflowReminder { get; set; } =
        new List<WorkflowReminderDbModel>();
}
