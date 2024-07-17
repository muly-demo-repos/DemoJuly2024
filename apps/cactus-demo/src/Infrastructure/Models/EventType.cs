using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemo.Core.Enums;

namespace CactusDemo.Infrastructure.Models;

[Table("EventTypes")]
public class EventTypeDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string Title { get; set; }

    [Required()]
    [StringLength(256)]
    public string Slug { get; set; }

    [StringLength(256)]
    public string? Description { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int Position { get; set; }

    public string? Locations { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int Length { get; set; }

    [Required()]
    public bool Hidden { get; set; }

    [Range(0, 99999999999)]
    public int? UserId { get; set; }

    [StringLength(256)]
    public string? EventName { get; set; }

    [StringLength(256)]
    public string? TimeZone { get; set; }

    [Required()]
    public PeriodTypeEnum PeriodType { get; set; } = PeriodTypeEnum.UNLIMITED;

    public DateTime? PeriodStartDate { get; set; }

    public DateTime? PeriodEndDate { get; set; }

    [Range(0, 99999999999)]
    public int? PeriodDays { get; set; }

    public bool? PeriodCountCalendarDays { get; set; }

    [Required()]
    public bool RequiresConfirmation { get; set; }

    public string? RecurringEvent { get; set; }

    [Required()]
    public bool DisableGuests { get; set; }

    [Required()]
    public bool HideCalendarNotes { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int MinimumBookingNotice { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int BeforeEventBuffer { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int AfterEventBuffer { get; set; }

    [Range(0, 99999999999)]
    public int? SeatsPerTimeSlot { get; set; }

    public SchedulingTypeEnum? SchedulingType { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int Price { get; set; }

    [Required()]
    [StringLength(256)]
    public string Currency { get; set; }

    [Range(0, 99999999999)]
    public int? SlotInterval { get; set; }

    public string? Metadata { get; set; }

    [StringLength(256)]
    public string? SuccessRedirectUrl { get; set; }

    public int? ScheduleId { get; set; }

    [ForeignKey(nameof(ScheduleId))]
    public ScheduleDbModel? Schedule { get; set; } = null;

    public int? TeamId { get; set; }

    [ForeignKey(nameof(TeamId))]
    public TeamDbModel? Team { get; set; } = null;

    public List<UserDbModel> Users { get; set; } = new List<UserDbModel>();

    public List<AvailabilityDbModel>? Availability { get; set; } = new List<AvailabilityDbModel>();

    public List<BookingDbModel>? Booking { get; set; } = new List<BookingDbModel>();

    public DestinationCalendarDbModel? DestinationCalendar { get; set; } = null;

    public List<EventTypeCustomInputDbModel>? EventTypeCustomInput { get; set; } =
        new List<EventTypeCustomInputDbModel>();

    public HashedLinkDbModel? HashedLink { get; set; } = null;

    public List<WebhookDbModel>? Webhook { get; set; } = new List<WebhookDbModel>();

    public List<WorkflowsOnEventTypeDbModel>? WorkflowsOnEventTypes { get; set; } =
        new List<WorkflowsOnEventTypeDbModel>();
}
