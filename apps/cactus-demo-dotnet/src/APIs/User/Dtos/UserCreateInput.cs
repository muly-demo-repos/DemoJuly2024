using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

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

    public DateTime CreatedDate { get; set; }

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

    public List<EventType>? EventTypes { get; set; }

    public List<Credential>? Credentials { get; set; }

    public DestinationCalendar? DestinationCalendar { get; set; }

    public List<Membership>? Teams { get; set; }

    public List<Booking>? Bookings { get; set; }

    public List<Schedule>? Schedules { get; set; }

    public List<Availability>? Availability { get; set; }

    public List<SelectedCalendar>? SelectedCalendars { get; set; }

    public List<Webhook>? Webhooks { get; set; }

    public List<Impersonation>? ImpersonatedUsers { get; set; }

    public List<Impersonation>? ImpersonatedBy { get; set; }

    public List<ApiKey>? ApiKeys { get; set; }

    public List<Account>? Accounts { get; set; }

    public List<Session>? Sessions { get; set; }

    public List<Feedback>? Feedback { get; set; }

    public List<Workflow>? Workflows { get; set; }
}
