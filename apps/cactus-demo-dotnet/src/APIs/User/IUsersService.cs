using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IUsersService
{
    /// <summary>
    /// Create one User
    /// </summary>
    public Task<User> CreateUser(UserCreateInput user);

    /// <summary>
    /// Delete one User
    /// </summary>
    public Task DeleteUser(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Users
    /// </summary>
    public Task<List<User>> Users(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Get one User
    /// </summary>
    public Task<User> User(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one User
    /// </summary>
    public Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Accounts records to User
    /// </summary>
    public Task ConnectAccounts(
        UserWhereUniqueInput uniqueId,
        AccountWhereUniqueInput[] accountsId
    );

    /// <summary>
    /// Connect multiple Api Keys records to User
    /// </summary>
    public Task ConnectApiKeys(UserWhereUniqueInput uniqueId, ApiKeyWhereUniqueInput[] apiKeysId);

    /// <summary>
    /// Connect multiple Availability records to User
    /// </summary>
    public Task ConnectAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Connect multiple Bookings records to User
    /// </summary>
    public Task ConnectBookings(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Connect multiple Credentials records to User
    /// </summary>
    public Task ConnectCredentials(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    );

    /// <summary>
    /// Connect multiple Event Types records to User
    /// </summary>
    public Task ConnectEventTypes(
        UserWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Connect multiple Feedback records to User
    /// </summary>
    public Task ConnectFeedback(
        UserWhereUniqueInput uniqueId,
        FeedbackWhereUniqueInput[] feedbacksId
    );

    /// <summary>
    /// Connect multiple Impersonated By records to User
    /// </summary>
    public Task ConnectImpersonatedBy(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Connect multiple Impersonated Users records to User
    /// </summary>
    public Task ConnectImpersonatedUsers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Connect multiple Schedules records to User
    /// </summary>
    public Task ConnectSchedules(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Connect multiple Selected Calendars records to User
    /// </summary>
    public Task ConnectSelectedCalendars(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    );

    /// <summary>
    /// Connect multiple Sessions records to User
    /// </summary>
    public Task ConnectSessions(
        UserWhereUniqueInput uniqueId,
        SessionWhereUniqueInput[] sessionsId
    );

    /// <summary>
    /// Connect multiple Teams records to User
    /// </summary>
    public Task ConnectTeams(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Connect multiple Webhooks records to User
    /// </summary>
    public Task ConnectWebhooks(
        UserWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Connect multiple Workflows records to User
    /// </summary>
    public Task ConnectWorkflows(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    );

    /// <summary>
    /// Disconnect multiple Accounts records from User
    /// </summary>
    public Task DisconnectAccounts(
        UserWhereUniqueInput uniqueId,
        AccountWhereUniqueInput[] accountsId
    );

    /// <summary>
    /// Disconnect multiple Api Keys records from User
    /// </summary>
    public Task DisconnectApiKeys(
        UserWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    );

    /// <summary>
    /// Disconnect multiple Availability records from User
    /// </summary>
    public Task DisconnectAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Disconnect multiple Bookings records from User
    /// </summary>
    public Task DisconnectBookings(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Disconnect multiple Credentials records from User
    /// </summary>
    public Task DisconnectCredentials(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    );

    /// <summary>
    /// Disconnect multiple Event Types records from User
    /// </summary>
    public Task DisconnectEventTypes(
        UserWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Disconnect multiple Feedback records from User
    /// </summary>
    public Task DisconnectFeedback(
        UserWhereUniqueInput uniqueId,
        FeedbackWhereUniqueInput[] feedbacksId
    );

    /// <summary>
    /// Disconnect multiple Impersonated By records from User
    /// </summary>
    public Task DisconnectImpersonatedBy(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Disconnect multiple Impersonated Users records from User
    /// </summary>
    public Task DisconnectImpersonatedUsers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Disconnect multiple Schedules records from User
    /// </summary>
    public Task DisconnectSchedules(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Disconnect multiple Selected Calendars records from User
    /// </summary>
    public Task DisconnectSelectedCalendars(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    );

    /// <summary>
    /// Disconnect multiple Sessions records from User
    /// </summary>
    public Task DisconnectSessions(
        UserWhereUniqueInput uniqueId,
        SessionWhereUniqueInput[] sessionsId
    );

    /// <summary>
    /// Disconnect multiple Teams records from User
    /// </summary>
    public Task DisconnectTeams(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Disconnect multiple Webhooks records from User
    /// </summary>
    public Task DisconnectWebhooks(
        UserWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Disconnect multiple Workflows records from User
    /// </summary>
    public Task DisconnectWorkflows(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    );

    /// <summary>
    /// Find multiple Accounts records for User
    /// </summary>
    public Task<List<Account>> FindAccounts(
        UserWhereUniqueInput uniqueId,
        AccountFindManyArgs AccountFindManyArgs
    );

    /// <summary>
    /// Find multiple Api Keys records for User
    /// </summary>
    public Task<List<ApiKey>> FindApiKeys(
        UserWhereUniqueInput uniqueId,
        ApiKeyFindManyArgs ApiKeyFindManyArgs
    );

    /// <summary>
    /// Find multiple Availability records for User
    /// </summary>
    public Task<List<Availability>> FindAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityFindManyArgs AvailabilityFindManyArgs
    );

    /// <summary>
    /// Find multiple Bookings records for User
    /// </summary>
    public Task<List<Booking>> FindBookings(
        UserWhereUniqueInput uniqueId,
        BookingFindManyArgs BookingFindManyArgs
    );

    /// <summary>
    /// Find multiple Credentials records for User
    /// </summary>
    public Task<List<Credential>> FindCredentials(
        UserWhereUniqueInput uniqueId,
        CredentialFindManyArgs CredentialFindManyArgs
    );

    /// <summary>
    /// Find multiple Event Types records for User
    /// </summary>
    public Task<List<EventType>> FindEventTypes(
        UserWhereUniqueInput uniqueId,
        EventTypeFindManyArgs EventTypeFindManyArgs
    );

    /// <summary>
    /// Find multiple Feedback records for User
    /// </summary>
    public Task<List<Feedback>> FindFeedback(
        UserWhereUniqueInput uniqueId,
        FeedbackFindManyArgs FeedbackFindManyArgs
    );

    /// <summary>
    /// Find multiple Impersonated By records for User
    /// </summary>
    public Task<List<Impersonation>> FindImpersonatedBy(
        UserWhereUniqueInput uniqueId,
        ImpersonationFindManyArgs ImpersonationFindManyArgs
    );

    /// <summary>
    /// Find multiple Impersonated Users records for User
    /// </summary>
    public Task<List<Impersonation>> FindImpersonatedUsers(
        UserWhereUniqueInput uniqueId,
        ImpersonationFindManyArgs ImpersonationFindManyArgs
    );

    /// <summary>
    /// Find multiple Schedules records for User
    /// </summary>
    public Task<List<Schedule>> FindSchedules(
        UserWhereUniqueInput uniqueId,
        ScheduleFindManyArgs ScheduleFindManyArgs
    );

    /// <summary>
    /// Find multiple Selected Calendars records for User
    /// </summary>
    public Task<List<SelectedCalendar>> FindSelectedCalendars(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarFindManyArgs SelectedCalendarFindManyArgs
    );

    /// <summary>
    /// Find multiple Sessions records for User
    /// </summary>
    public Task<List<Session>> FindSessions(
        UserWhereUniqueInput uniqueId,
        SessionFindManyArgs SessionFindManyArgs
    );

    /// <summary>
    /// Find multiple Teams records for User
    /// </summary>
    public Task<List<Membership>> FindTeams(
        UserWhereUniqueInput uniqueId,
        MembershipFindManyArgs MembershipFindManyArgs
    );

    /// <summary>
    /// Find multiple Webhooks records for User
    /// </summary>
    public Task<List<Webhook>> FindWebhooks(
        UserWhereUniqueInput uniqueId,
        WebhookFindManyArgs WebhookFindManyArgs
    );

    /// <summary>
    /// Find multiple Workflows records for User
    /// </summary>
    public Task<List<Workflow>> FindWorkflows(
        UserWhereUniqueInput uniqueId,
        WorkflowFindManyArgs WorkflowFindManyArgs
    );

    /// <summary>
    /// Get a Destination Calendar record for User
    /// </summary>
    public Task<DestinationCalendar> GetDestinationCalendar(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Accounts records for User
    /// </summary>
    public Task UpdateAccounts(UserWhereUniqueInput uniqueId, AccountWhereUniqueInput[] accountsId);

    /// <summary>
    /// Update multiple Api Keys records for User
    /// </summary>
    public Task UpdateApiKeys(UserWhereUniqueInput uniqueId, ApiKeyWhereUniqueInput[] apiKeysId);

    /// <summary>
    /// Update multiple Availability records for User
    /// </summary>
    public Task UpdateAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Update multiple Bookings records for User
    /// </summary>
    public Task UpdateBookings(UserWhereUniqueInput uniqueId, BookingWhereUniqueInput[] bookingsId);

    /// <summary>
    /// Update multiple Credentials records for User
    /// </summary>
    public Task UpdateCredentials(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    );

    /// <summary>
    /// Update multiple Event Types records for User
    /// </summary>
    public Task UpdateEventTypes(
        UserWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    );

    /// <summary>
    /// Update multiple Feedback records for User
    /// </summary>
    public Task UpdateFeedback(
        UserWhereUniqueInput uniqueId,
        FeedbackWhereUniqueInput[] feedbacksId
    );

    /// <summary>
    /// Update multiple Impersonated By records for User
    /// </summary>
    public Task UpdateImpersonatedBy(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Update multiple Impersonated Users records for User
    /// </summary>
    public Task UpdateImpersonatedUsers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Update multiple Schedules records for User
    /// </summary>
    public Task UpdateSchedules(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Update multiple Selected Calendars records for User
    /// </summary>
    public Task UpdateSelectedCalendars(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    );

    /// <summary>
    /// Update multiple Sessions records for User
    /// </summary>
    public Task UpdateSessions(UserWhereUniqueInput uniqueId, SessionWhereUniqueInput[] sessionsId);

    /// <summary>
    /// Update multiple Teams records for User
    /// </summary>
    public Task UpdateTeams(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Update multiple Webhooks records for User
    /// </summary>
    public Task UpdateWebhooks(UserWhereUniqueInput uniqueId, WebhookWhereUniqueInput[] webhooksId);

    /// <summary>
    /// Update multiple Workflows records for User
    /// </summary>
    public Task UpdateWorkflows(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    );
}
