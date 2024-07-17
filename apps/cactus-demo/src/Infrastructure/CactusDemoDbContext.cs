using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.Infrastructure;

public class CactusDemoDbContext : DbContext
{
    public CactusDemoDbContext(DbContextOptions<CactusDemoDbContext> options)
        : base(options) { }

    public DbSet<AccountDbModel> Accounts { get; set; }

    public DbSet<ApiKeyDbModel> ApiKeys { get; set; }

    public DbSet<AppModelDbModel> AppModels { get; set; }

    public DbSet<AttendeeDbModel> Attendees { get; set; }

    public DbSet<AvailabilityDbModel> Availabilities { get; set; }

    public DbSet<BookingDbModel> Bookings { get; set; }

    public DbSet<BookingReferenceDbModel> BookingReferences { get; set; }

    public DbSet<CredentialDbModel> Credentials { get; set; }

    public DbSet<DailyEventReferenceDbModel> DailyEventReferences { get; set; }

    public DbSet<DestinationCalendarDbModel> DestinationCalendars { get; set; }

    public DbSet<EventTypeDbModel> EventTypes { get; set; }

    public DbSet<EventTypeCustomInputDbModel> EventTypeCustomInputs { get; set; }

    public DbSet<FeedbackDbModel> Feedbacks { get; set; }

    public DbSet<HashedLinkDbModel> HashedLinks { get; set; }

    public DbSet<ImpersonationDbModel> Impersonations { get; set; }

    public DbSet<MembershipDbModel> Memberships { get; set; }

    public DbSet<PaymentDbModel> Payments { get; set; }

    public DbSet<ReminderMailDbModel> ReminderMails { get; set; }

    public DbSet<ResetPasswordRequestDbModel> ResetPasswordRequests { get; set; }

    public DbSet<ScheduleDbModel> Schedules { get; set; }

    public DbSet<SelectedCalendarDbModel> SelectedCalendars { get; set; }

    public DbSet<SessionDbModel> Sessions { get; set; }

    public DbSet<TeamDbModel> Teams { get; set; }

    public DbSet<VerificationTokenDbModel> VerificationTokens { get; set; }

    public DbSet<WebhookDbModel> Webhooks { get; set; }

    public DbSet<WorkflowDbModel> Workflows { get; set; }

    public DbSet<WorkflowReminderDbModel> WorkflowReminders { get; set; }

    public DbSet<WorkflowStepDbModel> WorkflowSteps { get; set; }

    public DbSet<WorkflowsOnEventTypeDbModel> WorkflowsOnEventTypes { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
