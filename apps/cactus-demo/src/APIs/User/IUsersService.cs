using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

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
    /// Connect multiple Account records to User
    /// </summary>
    public Task ConnectAccount(UserWhereUniqueInput uniqueId, AccountWhereUniqueInput[] accountsId);

    /// <summary>
    /// Connect multiple Api Key records to User
    /// </summary>
    public Task ConnectApiKey(UserWhereUniqueInput uniqueId, ApiKeyWhereUniqueInput[] apiKeysId);

    /// <summary>
    /// Connect multiple Availability records to User
    /// </summary>
    public Task ConnectAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Connect multiple Booking records to User
    /// </summary>
    public Task ConnectBooking(UserWhereUniqueInput uniqueId, BookingWhereUniqueInput[] bookingsId);

    /// <summary>
    /// Connect multiple Credential records to User
    /// </summary>
    public Task ConnectCredential(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    );

    /// <summary>
    /// Connect multiple Event Type records to User
    /// </summary>
    public Task ConnectEventType(
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
    /// Connect multiple Impersonations Impersonations Impersonated By Id Tousers records to User
    /// </summary>
    public Task ConnectImpersonationsImpersonationsImpersonatedByIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Connect multiple Impersonations Impersonations Impersonated User Id Tousers records to User
    /// </summary>
    public Task ConnectImpersonationsImpersonationsImpersonatedUserIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Connect multiple Membership records to User
    /// </summary>
    public Task ConnectMembership(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Connect multiple Schedule records to User
    /// </summary>
    public Task ConnectSchedule(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Connect multiple Selected Calendar records to User
    /// </summary>
    public Task ConnectSelectedCalendar(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    );

    /// <summary>
    /// Connect multiple Session records to User
    /// </summary>
    public Task ConnectSession(UserWhereUniqueInput uniqueId, SessionWhereUniqueInput[] sessionsId);

    /// <summary>
    /// Connect multiple Webhook records to User
    /// </summary>
    public Task ConnectWebhook(UserWhereUniqueInput uniqueId, WebhookWhereUniqueInput[] webhooksId);

    /// <summary>
    /// Connect multiple Workflow records to User
    /// </summary>
    public Task ConnectWorkflow(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    );

    /// <summary>
    /// Disconnect multiple Account records from User
    /// </summary>
    public Task DisconnectAccount(
        UserWhereUniqueInput uniqueId,
        AccountWhereUniqueInput[] accountsId
    );

    /// <summary>
    /// Disconnect multiple Api Key records from User
    /// </summary>
    public Task DisconnectApiKey(UserWhereUniqueInput uniqueId, ApiKeyWhereUniqueInput[] apiKeysId);

    /// <summary>
    /// Disconnect multiple Availability records from User
    /// </summary>
    public Task DisconnectAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Disconnect multiple Booking records from User
    /// </summary>
    public Task DisconnectBooking(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Disconnect multiple Credential records from User
    /// </summary>
    public Task DisconnectCredential(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    );

    /// <summary>
    /// Disconnect multiple Event Type records from User
    /// </summary>
    public Task DisconnectEventType(
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
    /// Disconnect multiple Impersonations Impersonations Impersonated By Id Tousers records from User
    /// </summary>
    public Task DisconnectImpersonationsImpersonationsImpersonatedByIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Disconnect multiple Impersonations Impersonations Impersonated User Id Tousers records from User
    /// </summary>
    public Task DisconnectImpersonationsImpersonationsImpersonatedUserIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Disconnect multiple Membership records from User
    /// </summary>
    public Task DisconnectMembership(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Disconnect multiple Schedule records from User
    /// </summary>
    public Task DisconnectSchedule(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Disconnect multiple Selected Calendar records from User
    /// </summary>
    public Task DisconnectSelectedCalendar(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    );

    /// <summary>
    /// Disconnect multiple Session records from User
    /// </summary>
    public Task DisconnectSession(
        UserWhereUniqueInput uniqueId,
        SessionWhereUniqueInput[] sessionsId
    );

    /// <summary>
    /// Disconnect multiple Webhook records from User
    /// </summary>
    public Task DisconnectWebhook(
        UserWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Disconnect multiple Workflow records from User
    /// </summary>
    public Task DisconnectWorkflow(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    );

    /// <summary>
    /// Find multiple Account records for User
    /// </summary>
    public Task<List<Account>> FindAccount(
        UserWhereUniqueInput uniqueId,
        AccountFindManyArgs AccountFindManyArgs
    );

    /// <summary>
    /// Find multiple Api Key records for User
    /// </summary>
    public Task<List<ApiKey>> FindApiKey(
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
    /// Find multiple Booking records for User
    /// </summary>
    public Task<List<Booking>> FindBooking(
        UserWhereUniqueInput uniqueId,
        BookingFindManyArgs BookingFindManyArgs
    );

    /// <summary>
    /// Find multiple Credential records for User
    /// </summary>
    public Task<List<Credential>> FindCredential(
        UserWhereUniqueInput uniqueId,
        CredentialFindManyArgs CredentialFindManyArgs
    );

    /// <summary>
    /// Find multiple Event Type records for User
    /// </summary>
    public Task<List<EventType>> FindEventType(
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
    /// Find multiple Impersonations Impersonations Impersonated By Id Tousers records for User
    /// </summary>
    public Task<List<Impersonation>> FindImpersonationsImpersonationsImpersonatedByIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationFindManyArgs ImpersonationFindManyArgs
    );

    /// <summary>
    /// Find multiple Impersonations Impersonations Impersonated User Id Tousers records for User
    /// </summary>
    public Task<List<Impersonation>> FindImpersonationsImpersonationsImpersonatedUserIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationFindManyArgs ImpersonationFindManyArgs
    );

    /// <summary>
    /// Find multiple Membership records for User
    /// </summary>
    public Task<List<Membership>> FindMembership(
        UserWhereUniqueInput uniqueId,
        MembershipFindManyArgs MembershipFindManyArgs
    );

    /// <summary>
    /// Find multiple Schedule records for User
    /// </summary>
    public Task<List<Schedule>> FindSchedule(
        UserWhereUniqueInput uniqueId,
        ScheduleFindManyArgs ScheduleFindManyArgs
    );

    /// <summary>
    /// Find multiple Selected Calendar records for User
    /// </summary>
    public Task<List<SelectedCalendar>> FindSelectedCalendar(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarFindManyArgs SelectedCalendarFindManyArgs
    );

    /// <summary>
    /// Find multiple Session records for User
    /// </summary>
    public Task<List<Session>> FindSession(
        UserWhereUniqueInput uniqueId,
        SessionFindManyArgs SessionFindManyArgs
    );

    /// <summary>
    /// Find multiple Webhook records for User
    /// </summary>
    public Task<List<Webhook>> FindWebhook(
        UserWhereUniqueInput uniqueId,
        WebhookFindManyArgs WebhookFindManyArgs
    );

    /// <summary>
    /// Find multiple Workflow records for User
    /// </summary>
    public Task<List<Workflow>> FindWorkflow(
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
    /// Update multiple Account records for User
    /// </summary>
    public Task UpdateAccount(UserWhereUniqueInput uniqueId, AccountWhereUniqueInput[] accountsId);

    /// <summary>
    /// Update multiple Api Key records for User
    /// </summary>
    public Task UpdateApiKey(UserWhereUniqueInput uniqueId, ApiKeyWhereUniqueInput[] apiKeysId);

    /// <summary>
    /// Update multiple Availability records for User
    /// </summary>
    public Task UpdateAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    );

    /// <summary>
    /// Update multiple Booking records for User
    /// </summary>
    public Task UpdateBooking(UserWhereUniqueInput uniqueId, BookingWhereUniqueInput[] bookingsId);

    /// <summary>
    /// Update multiple Credential records for User
    /// </summary>
    public Task UpdateCredential(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    );

    /// <summary>
    /// Update multiple Event Type records for User
    /// </summary>
    public Task UpdateEventType(
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
    /// Update multiple Impersonations Impersonations Impersonated By Id Tousers records for User
    /// </summary>
    public Task UpdateImpersonationsImpersonationsImpersonatedByIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Update multiple Impersonations Impersonations Impersonated User Id Tousers records for User
    /// </summary>
    public Task UpdateImpersonationsImpersonationsImpersonatedUserIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    );

    /// <summary>
    /// Update multiple Membership records for User
    /// </summary>
    public Task UpdateMembership(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    );

    /// <summary>
    /// Update multiple Schedule records for User
    /// </summary>
    public Task UpdateSchedule(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Update multiple Selected Calendar records for User
    /// </summary>
    public Task UpdateSelectedCalendar(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    );

    /// <summary>
    /// Update multiple Session records for User
    /// </summary>
    public Task UpdateSession(UserWhereUniqueInput uniqueId, SessionWhereUniqueInput[] sessionsId);

    /// <summary>
    /// Update multiple Webhook records for User
    /// </summary>
    public Task UpdateWebhook(UserWhereUniqueInput uniqueId, WebhookWhereUniqueInput[] webhooksId);

    /// <summary>
    /// Update multiple Workflow records for User
    /// </summary>
    public Task UpdateWorkflow(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    );
}
