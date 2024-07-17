using CactusDemoDotnet.APIs;

namespace CactusDemoDotnet;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountsService, AccountsService>();
        services.AddScoped<IApiKeysService, ApiKeysService>();
        services.AddScoped<IAppModelsService, AppModelsService>();
        services.AddScoped<IAttendeesService, AttendeesService>();
        services.AddScoped<IAvailabilitiesService, AvailabilitiesService>();
        services.AddScoped<IBookingsService, BookingsService>();
        services.AddScoped<IBookingReferencesService, BookingReferencesService>();
        services.AddScoped<ICredentialsService, CredentialsService>();
        services.AddScoped<IDailyEventReferencesService, DailyEventReferencesService>();
        services.AddScoped<IDestinationCalendarsService, DestinationCalendarsService>();
        services.AddScoped<IEventTypesService, EventTypesService>();
        services.AddScoped<IEventTypeCustomInputsService, EventTypeCustomInputsService>();
        services.AddScoped<IFeedbacksService, FeedbacksService>();
        services.AddScoped<IHashedLinksService, HashedLinksService>();
        services.AddScoped<IImpersonationsService, ImpersonationsService>();
        services.AddScoped<IMembershipsService, MembershipsService>();
        services.AddScoped<IPaymentsService, PaymentsService>();
        services.AddScoped<IReminderMailsService, ReminderMailsService>();
        services.AddScoped<IResetPasswordRequestsService, ResetPasswordRequestsService>();
        services.AddScoped<ISchedulesService, SchedulesService>();
        services.AddScoped<ISelectedCalendarsService, SelectedCalendarsService>();
        services.AddScoped<ISessionsService, SessionsService>();
        services.AddScoped<ITeamsService, TeamsService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IVerificationTokensService, VerificationTokensService>();
        services.AddScoped<IWebhooksService, WebhooksService>();
        services.AddScoped<IWorkflowsService, WorkflowsService>();
        services.AddScoped<IWorkflowRemindersService, WorkflowRemindersService>();
        services.AddScoped<IWorkflowsOnEventTypesService, WorkflowsOnEventTypesService>();
        services.AddScoped<IWorkflowStepsService, WorkflowStepsService>();
    }
}
