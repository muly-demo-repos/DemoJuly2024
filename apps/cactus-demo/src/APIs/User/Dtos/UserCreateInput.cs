using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class UserCreateInput
{
    public int? Id { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string Email { get; set; }

    public DateTime? EmailVerified { get; set; }

    public string? Password { get; set; }

    public string? Bio { get; set; }

    public string? Avatar { get; set; }

    public string TimeZone { get; set; }

    public string WeekStart { get; set; }

    public int StartTime { get; set; }

    public int EndTime { get; set; }

    public int BufferTime { get; set; }

    public bool HideBranding { get; set; }

    public string? Theme { get; set; }

    public DateTime Created { get; set; }

    public DateTime? TrialEndsAt { get; set; }

    public int? DefaultScheduleId { get; set; }

    public bool CompletedOnboarding { get; set; }

    public string? Locale { get; set; }

    public int? TimeFormat { get; set; }

    public string? TwoFactorSecret { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public IdentityProviderEnum IdentityProvider { get; set; }

    public string? IdentityProviderId { get; set; }

    public int? InvitedTo { get; set; }

    public PlanEnum Plan { get; set; }

    public string BrandColor { get; set; }

    public string DarkBrandColor { get; set; }

    public bool Away { get; set; }

    public bool? AllowDynamicBooking { get; set; }

    public string? Metadata { get; set; }

    public bool? Verified { get; set; }

    public RoleEnum Role { get; set; }

    public bool DisableImpersonation { get; set; }

    public List<Account>? Account { get; set; }

    public List<ApiKey>? ApiKey { get; set; }

    public List<Availability>? Availability { get; set; }

    public List<Booking>? Booking { get; set; }

    public List<Credential>? Credential { get; set; }

    public DestinationCalendar? DestinationCalendar { get; set; }

    public List<EventType>? EventType { get; set; }

    public List<Feedback>? Feedback { get; set; }

    public List<Impersonation>? ImpersonationsImpersonationsImpersonatedByIdTousers { get; set; }

    public List<Impersonation>? ImpersonationsImpersonationsImpersonatedUserIdTousers { get; set; }

    public List<Membership>? Membership { get; set; }

    public List<Schedule>? Schedule { get; set; }

    public List<SelectedCalendar>? SelectedCalendar { get; set; }

    public List<Session>? Session { get; set; }

    public List<Webhook>? Webhook { get; set; }

    public List<Workflow>? Workflow { get; set; }
}
