using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class BookingCreateInput
{
    public int? Id { get; set; }

    public string Uid { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public string? CustomInputs { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string? Location { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public StatusEnum Status { get; set; }

    public bool Paid { get; set; }

    public string? CancellationReason { get; set; }

    public string? RejectionReason { get; set; }

    public string? DynamicEventSlugRef { get; set; }

    public string? DynamicGroupSlugRef { get; set; }

    public bool? Rescheduled { get; set; }

    public string? FromReschedule { get; set; }

    public string? RecurringEventId { get; set; }

    public string? SmsReminderNumber { get; set; }

    public EventType? EventType { get; set; }

    public User? Users { get; set; }

    public List<Attendee>? Attendee { get; set; }

    public List<BookingReference>? BookingReference { get; set; }

    public DailyEventReference? DailyEventReference { get; set; }

    public DestinationCalendar? DestinationCalendar { get; set; }

    public List<Payment>? Payment { get; set; }

    public List<WorkflowReminder>? WorkflowReminder { get; set; }
}
