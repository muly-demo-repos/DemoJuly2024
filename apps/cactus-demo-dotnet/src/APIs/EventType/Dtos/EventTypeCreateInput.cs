using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class EventTypeCreateInput
{
    public int? Id { get; set; }

    public string Title { get; set; }

    public string Slug { get; set; }

    public string? Description { get; set; }

    public int Position { get; set; }

    public string? Locations { get; set; }

    public int Length { get; set; }

    public bool Hidden { get; set; }

    public List<User> Users { get; set; }

    public int? UserId { get; set; }

    public Team? Team { get; set; }

    public string? EventName { get; set; }

    public string? TimeZone { get; set; }

    public PeriodTypeEnum PeriodType { get; set; }

    public DateTime? PeriodStartDate { get; set; }

    public DateTime? PeriodEndDate { get; set; }

    public int? PeriodDays { get; set; }

    public bool? PeriodCountCalendarDays { get; set; }

    public bool RequiresConfirmation { get; set; }

    public string? RecurringEvent { get; set; }

    public bool DisableGuests { get; set; }

    public bool HideCalendarNotes { get; set; }

    public int MinimumBookingNotice { get; set; }

    public int BeforeEventBuffer { get; set; }

    public int AfterEventBuffer { get; set; }

    public int? SeatsPerTimeSlot { get; set; }

    public SchedulingTypeEnum? SchedulingType { get; set; }

    public Schedule? Schedule { get; set; }

    public int Price { get; set; }

    public string Currency { get; set; }

    public int? SlotInterval { get; set; }

    public string? Metadata { get; set; }

    public string? SuccessRedirectUrl { get; set; }

    public DestinationCalendar? DestinationCalendar { get; set; }

    public List<Booking>? Bookings { get; set; }

    public List<Availability>? Availability { get; set; }

    public List<EventTypeCustomInput>? CustomInputs { get; set; }

    public List<Webhook>? Webhooks { get; set; }

    public HashedLink? HashedLink { get; set; }

    public List<WorkflowsOnEventType>? Workflows { get; set; }
}
