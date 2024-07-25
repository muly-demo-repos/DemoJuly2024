using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class UserWhereInput
{
    public int? Id { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateTime? EmailVerified { get; set; }

    public string? Password { get; set; }

    public string? Bio { get; set; }

    public string? Avatar { get; set; }

    public string? TimeZone { get; set; }

    public string? WeekStart { get; set; }

    public int? StartTime { get; set; }

    public int? EndTime { get; set; }

    public int? BufferTime { get; set; }

    public bool? HideBranding { get; set; }

    public string? Theme { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? TrialEndsAt { get; set; }

    public int? DefaultScheduleId { get; set; }

    public bool? CompletedOnboarding { get; set; }

    public string? Locale { get; set; }

    public int? TimeFormat { get; set; }

    public string? TwoFactorSecret { get; set; }

    public bool? TwoFactorEnabled { get; set; }

    public IdentityProviderEnum? IdentityProvider { get; set; }

    public string? IdentityProviderId { get; set; }

    public int? InvitedTo { get; set; }

    public PlanEnum? Plan { get; set; }

    public string? BrandColor { get; set; }

    public string? DarkBrandColor { get; set; }

    public bool? Away { get; set; }

    public bool? AllowDynamicBooking { get; set; }

    public string? Metadata { get; set; }

    public bool? Verified { get; set; }

    public RoleEnum? Role { get; set; }

    public bool? DisableImpersonation { get; set; }

    public List<string>? Account { get; set; }

    public List<string>? ApiKey { get; set; }

    public List<int>? Availability { get; set; }

    public List<int>? Booking { get; set; }

    public List<int>? Credential { get; set; }

    public int? DestinationCalendar { get; set; }

    public List<int>? EventType { get; set; }

    public List<int>? Feedback { get; set; }

    public List<int>? ImpersonationsImpersonationsImpersonatedByIdTousers { get; set; }

    public List<int>? ImpersonationsImpersonationsImpersonatedUserIdTousers { get; set; }

    public List<int>? Membership { get; set; }

    public List<int>? Schedule { get; set; }

    public List<int>? SelectedCalendar { get; set; }

    public List<string>? Session { get; set; }

    public List<string>? Webhook { get; set; }

    public List<int>? Workflow { get; set; }
}
