using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemo.Core.Enums;

namespace CactusDemo.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [StringLength(256)]
    public string? Username { get; set; }

    [StringLength(256)]
    public string? Name { get; set; }

    [Required()]
    [StringLength(256)]
    public string Email { get; set; }

    public DateTime? EmailVerified { get; set; }

    [StringLength(256)]
    public string? Password { get; set; }

    [StringLength(256)]
    public string? Bio { get; set; }

    [StringLength(256)]
    public string? Avatar { get; set; }

    [Required()]
    [StringLength(256)]
    public string TimeZone { get; set; }

    [Required()]
    [StringLength(256)]
    public string WeekStart { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int StartTime { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int EndTime { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int BufferTime { get; set; }

    [Required()]
    public bool HideBranding { get; set; }

    [StringLength(256)]
    public string? Theme { get; set; }

    [Required()]
    public DateTime Created { get; set; }

    public DateTime? TrialEndsAt { get; set; }

    [Range(0, 99999999999)]
    public int? DefaultScheduleId { get; set; }

    [Required()]
    public bool CompletedOnboarding { get; set; }

    [StringLength(256)]
    public string? Locale { get; set; }

    [Range(0, 99999999999)]
    public int? TimeFormat { get; set; }

    [StringLength(256)]
    public string? TwoFactorSecret { get; set; }

    [Required()]
    public bool TwoFactorEnabled { get; set; }

    [Required()]
    public IdentityProviderEnum IdentityProvider { get; set; } = IdentityProviderEnum.CAL;

    [StringLength(256)]
    public string? IdentityProviderId { get; set; }

    [Range(0, 99999999999)]
    public int? InvitedTo { get; set; }

    [Required()]
    public PlanEnum Plan { get; set; } = PlanEnum.FREE;

    [Required()]
    [StringLength(256)]
    public string BrandColor { get; set; }

    [Required()]
    [StringLength(256)]
    public string DarkBrandColor { get; set; }

    [Required()]
    public bool Away { get; set; }

    public bool? AllowDynamicBooking { get; set; }

    public string? Metadata { get; set; }

    public bool? Verified { get; set; }

    [Required()]
    public RoleEnum Role { get; set; } = RoleEnum.USER;

    [Required()]
    public bool DisableImpersonation { get; set; }

    public List<AccountDbModel>? Account { get; set; } = new List<AccountDbModel>();

    public List<ApiKeyDbModel>? ApiKey { get; set; } = new List<ApiKeyDbModel>();

    public List<AvailabilityDbModel>? Availability { get; set; } = new List<AvailabilityDbModel>();

    public List<BookingDbModel>? Booking { get; set; } = new List<BookingDbModel>();

    public List<CredentialDbModel>? Credential { get; set; } = new List<CredentialDbModel>();

    public DestinationCalendarDbModel? DestinationCalendar { get; set; } = null;

    public List<EventTypeDbModel>? EventType { get; set; } = new List<EventTypeDbModel>();

    public List<FeedbackDbModel>? Feedback { get; set; } = new List<FeedbackDbModel>();

    public List<ImpersonationDbModel>? ImpersonationsImpersonationsImpersonatedByIdTousers { get; set; } =
        new List<ImpersonationDbModel>();

    public List<ImpersonationDbModel>? ImpersonationsImpersonationsImpersonatedUserIdTousers { get; set; } =
        new List<ImpersonationDbModel>();

    public List<MembershipDbModel>? Membership { get; set; } = new List<MembershipDbModel>();

    public List<ScheduleDbModel>? Schedule { get; set; } = new List<ScheduleDbModel>();

    public List<SelectedCalendarDbModel>? SelectedCalendar { get; set; } =
        new List<SelectedCalendarDbModel>();

    public List<SessionDbModel>? Session { get; set; } = new List<SessionDbModel>();

    public List<WebhookDbModel>? Webhook { get; set; } = new List<WebhookDbModel>();

    public List<WorkflowDbModel>? Workflow { get; set; } = new List<WorkflowDbModel>();
}
