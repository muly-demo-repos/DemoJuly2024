using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class BookingWhereInput
{
    public int? Id { get; set; }

    public string? Uid { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? CustomInputs { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Location { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public StatusEnum? Status { get; set; }

    public bool? Paid { get; set; }

    public string? CancellationReason { get; set; }

    public string? RejectionReason { get; set; }

    public string? DynamicEventSlugRef { get; set; }

    public string? DynamicGroupSlugRef { get; set; }

    public bool? Rescheduled { get; set; }

    public string? FromReschedule { get; set; }

    public string? RecurringEventId { get; set; }

    public string? SmsReminderNumber { get; set; }

    public int? EventType { get; set; }

    public int? Users { get; set; }

    public List<int>? Attendee { get; set; }

    public List<int>? BookingReference { get; set; }

    public int? DailyEventReference { get; set; }

    public int? DestinationCalendar { get; set; }

    public List<int>? Payment { get; set; }

    public List<int>? WorkflowReminder { get; set; }
}
