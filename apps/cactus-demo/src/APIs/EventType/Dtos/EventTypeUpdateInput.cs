using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class EventTypeUpdateInput
{
    public int? Id { get; set; }

    public string? Title { get; set; }

    public string? Slug { get; set; }

    public string? Description { get; set; }

    public int? Position { get; set; }

    public string? Locations { get; set; }

    public int? Length { get; set; }

    public bool? Hidden { get; set; }

    public int? UserId { get; set; }

    public string? EventName { get; set; }

    public string? TimeZone { get; set; }

    public PeriodTypeEnum? PeriodType { get; set; }

    public DateTime? PeriodStartDate { get; set; }

    public DateTime? PeriodEndDate { get; set; }

    public int? PeriodDays { get; set; }

    public bool? PeriodCountCalendarDays { get; set; }

    public bool? RequiresConfirmation { get; set; }

    public string? RecurringEvent { get; set; }

    public bool? DisableGuests { get; set; }

    public bool? HideCalendarNotes { get; set; }

    public int? MinimumBookingNotice { get; set; }

    public int? BeforeEventBuffer { get; set; }

    public int? AfterEventBuffer { get; set; }

    public int? SeatsPerTimeSlot { get; set; }

    public SchedulingTypeEnum? SchedulingType { get; set; }

    public int? Price { get; set; }

    public string? Currency { get; set; }

    public int? SlotInterval { get; set; }

    public string? Metadata { get; set; }

    public string? SuccessRedirectUrl { get; set; }

    public int? Schedule { get; set; }

    public int? Team { get; set; }

    public List<int>? Users { get; set; }

    public List<int>? Availability { get; set; }

    public List<int>? Booking { get; set; }

    public int? DestinationCalendar { get; set; }

    public List<int>? EventTypeCustomInput { get; set; }

    public int? HashedLink { get; set; }

    public List<string>? Webhook { get; set; }

    public List<int>? WorkflowsOnEventTypes { get; set; }
}
