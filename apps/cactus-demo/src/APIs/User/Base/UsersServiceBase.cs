using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class UsersServiceBase : IUsersService
{
    protected readonly CactusDemoDbContext _context;

    public UsersServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    public async Task<User> CreateUser(UserCreateInput createDto)
    {
        var user = new UserDbModel
        {
            Username = createDto.Username,
            Name = createDto.Name,
            Email = createDto.Email,
            EmailVerified = createDto.EmailVerified,
            Password = createDto.Password,
            Bio = createDto.Bio,
            Avatar = createDto.Avatar,
            TimeZone = createDto.TimeZone,
            WeekStart = createDto.WeekStart,
            StartTime = createDto.StartTime,
            EndTime = createDto.EndTime,
            BufferTime = createDto.BufferTime,
            HideBranding = createDto.HideBranding,
            Theme = createDto.Theme,
            Created = createDto.Created,
            TrialEndsAt = createDto.TrialEndsAt,
            DefaultScheduleId = createDto.DefaultScheduleId,
            CompletedOnboarding = createDto.CompletedOnboarding,
            Locale = createDto.Locale,
            TimeFormat = createDto.TimeFormat,
            TwoFactorSecret = createDto.TwoFactorSecret,
            TwoFactorEnabled = createDto.TwoFactorEnabled,
            IdentityProvider = createDto.IdentityProvider,
            IdentityProviderId = createDto.IdentityProviderId,
            InvitedTo = createDto.InvitedTo,
            Plan = createDto.Plan,
            BrandColor = createDto.BrandColor,
            DarkBrandColor = createDto.DarkBrandColor,
            Away = createDto.Away,
            AllowDynamicBooking = createDto.AllowDynamicBooking,
            Metadata = createDto.Metadata,
            Verified = createDto.Verified,
            Role = createDto.Role,
            DisableImpersonation = createDto.DisableImpersonation
        };

        if (createDto.Id != null)
        {
            user.Id = createDto.Id.Value;
        }
        if (createDto.Account != null)
        {
            user.Account = await _context
                .Accounts.Where(account => createDto.Account.Select(t => t.Id).Contains(account.Id))
                .ToListAsync();
        }

        if (createDto.ApiKey != null)
        {
            user.ApiKey = await _context
                .ApiKeys.Where(apiKey => createDto.ApiKey.Select(t => t.Id).Contains(apiKey.Id))
                .ToListAsync();
        }

        if (createDto.Availability != null)
        {
            user.Availability = await _context
                .Availabilities.Where(availability =>
                    createDto.Availability.Select(t => t.Id).Contains(availability.Id)
                )
                .ToListAsync();
        }

        if (createDto.Booking != null)
        {
            user.Booking = await _context
                .Bookings.Where(booking => createDto.Booking.Select(t => t.Id).Contains(booking.Id))
                .ToListAsync();
        }

        if (createDto.Credential != null)
        {
            user.Credential = await _context
                .Credentials.Where(credential =>
                    createDto.Credential.Select(t => t.Id).Contains(credential.Id)
                )
                .ToListAsync();
        }

        if (createDto.DestinationCalendar != null)
        {
            user.DestinationCalendar = await _context
                .DestinationCalendars.Where(destinationCalendar =>
                    createDto.DestinationCalendar.Id == destinationCalendar.Id
                )
                .FirstOrDefaultAsync();
        }

        if (createDto.EventType != null)
        {
            user.EventType = await _context
                .EventTypes.Where(eventType =>
                    createDto.EventType.Select(t => t.Id).Contains(eventType.Id)
                )
                .ToListAsync();
        }

        if (createDto.Feedback != null)
        {
            user.Feedback = await _context
                .Feedbacks.Where(feedback =>
                    createDto.Feedback.Select(t => t.Id).Contains(feedback.Id)
                )
                .ToListAsync();
        }

        if (createDto.ImpersonationsImpersonationsImpersonatedByIdTousers != null)
        {
            user.ImpersonationsImpersonationsImpersonatedByIdTousers = await _context
                .Impersonations.Where(impersonation =>
                    createDto
                        .ImpersonationsImpersonationsImpersonatedByIdTousers.Select(t => t.Id)
                        .Contains(impersonation.Id)
                )
                .ToListAsync();
        }

        if (createDto.Membership != null)
        {
            user.Membership = await _context
                .Memberships.Where(membership =>
                    createDto.Membership.Select(t => t.Id).Contains(membership.Id)
                )
                .ToListAsync();
        }

        if (createDto.Schedule != null)
        {
            user.Schedule = await _context
                .Schedules.Where(schedule =>
                    createDto.Schedule.Select(t => t.Id).Contains(schedule.Id)
                )
                .ToListAsync();
        }

        if (createDto.SelectedCalendar != null)
        {
            user.SelectedCalendar = await _context
                .SelectedCalendars.Where(selectedCalendar =>
                    createDto.SelectedCalendar.Select(t => t.Id).Contains(selectedCalendar.Id)
                )
                .ToListAsync();
        }

        if (createDto.Session != null)
        {
            user.Session = await _context
                .Sessions.Where(session => createDto.Session.Select(t => t.Id).Contains(session.Id))
                .ToListAsync();
        }

        if (createDto.Webhook != null)
        {
            user.Webhook = await _context
                .Webhooks.Where(webhook => createDto.Webhook.Select(t => t.Id).Contains(webhook.Id))
                .ToListAsync();
        }

        if (createDto.Workflow != null)
        {
            user.Workflow = await _context
                .Workflows.Where(workflow =>
                    createDto.Workflow.Select(t => t.Id).Contains(workflow.Id)
                )
                .ToListAsync();
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<UserDbModel>(user.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    public async Task DeleteUser(UserWhereUniqueInput uniqueId)
    {
        var user = await _context.Users.FindAsync(uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    public async Task<List<User>> Users(UserFindManyArgs findManyArgs)
    {
        var users = await _context
            .Users.Include(x => x.Account)
            .Include(x => x.ApiKey)
            .Include(x => x.Availability)
            .Include(x => x.Booking)
            .Include(x => x.Credential)
            .Include(x => x.DestinationCalendar)
            .Include(x => x.EventType)
            .Include(x => x.Feedback)
            .Include(x => x.ImpersonationsImpersonationsImpersonatedByIdTousers)
            .Include(x => x.Membership)
            .Include(x => x.Schedule)
            .Include(x => x.SelectedCalendar)
            .Include(x => x.Session)
            .Include(x => x.Webhook)
            .Include(x => x.Workflow)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return users.ConvertAll(user => user.ToDto());
    }

    /// <summary>
    /// Get one User
    /// </summary>
    public async Task<User> User(UserWhereUniqueInput uniqueId)
    {
        var users = await this.Users(
            new UserFindManyArgs { Where = new UserWhereInput { Id = uniqueId.Id } }
        );
        var user = users.FirstOrDefault();
        if (user == null)
        {
            throw new NotFoundException();
        }

        return user;
    }

    /// <summary>
    /// Update one User
    /// </summary>
    public async Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto)
    {
        var user = updateDto.ToModel(uniqueId);

        if (updateDto.Account != null)
        {
            user.Account = await _context
                .Accounts.Where(account => updateDto.Account.Select(t => t).Contains(account.Id))
                .ToListAsync();
        }

        if (updateDto.ApiKey != null)
        {
            user.ApiKey = await _context
                .ApiKeys.Where(apiKey => updateDto.ApiKey.Select(t => t).Contains(apiKey.Id))
                .ToListAsync();
        }

        if (updateDto.Availability != null)
        {
            user.Availability = await _context
                .Availabilities.Where(availability =>
                    updateDto.Availability.Select(t => t).Contains(availability.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Booking != null)
        {
            user.Booking = await _context
                .Bookings.Where(booking => updateDto.Booking.Select(t => t).Contains(booking.Id))
                .ToListAsync();
        }

        if (updateDto.Credential != null)
        {
            user.Credential = await _context
                .Credentials.Where(credential =>
                    updateDto.Credential.Select(t => t).Contains(credential.Id)
                )
                .ToListAsync();
        }

        if (updateDto.EventType != null)
        {
            user.EventType = await _context
                .EventTypes.Where(eventType =>
                    updateDto.EventType.Select(t => t).Contains(eventType.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Feedback != null)
        {
            user.Feedback = await _context
                .Feedbacks.Where(feedback =>
                    updateDto.Feedback.Select(t => t).Contains(feedback.Id)
                )
                .ToListAsync();
        }

        if (updateDto.ImpersonationsImpersonationsImpersonatedByIdTousers != null)
        {
            user.ImpersonationsImpersonationsImpersonatedByIdTousers = await _context
                .Impersonations.Where(impersonation =>
                    updateDto
                        .ImpersonationsImpersonationsImpersonatedByIdTousers.Select(t => t)
                        .Contains(impersonation.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Membership != null)
        {
            user.Membership = await _context
                .Memberships.Where(membership =>
                    updateDto.Membership.Select(t => t).Contains(membership.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Schedule != null)
        {
            user.Schedule = await _context
                .Schedules.Where(schedule =>
                    updateDto.Schedule.Select(t => t).Contains(schedule.Id)
                )
                .ToListAsync();
        }

        if (updateDto.SelectedCalendar != null)
        {
            user.SelectedCalendar = await _context
                .SelectedCalendars.Where(selectedCalendar =>
                    updateDto.SelectedCalendar.Select(t => t).Contains(selectedCalendar.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Session != null)
        {
            user.Session = await _context
                .Sessions.Where(session => updateDto.Session.Select(t => t).Contains(session.Id))
                .ToListAsync();
        }

        if (updateDto.Webhook != null)
        {
            user.Webhook = await _context
                .Webhooks.Where(webhook => updateDto.Webhook.Select(t => t).Contains(webhook.Id))
                .ToListAsync();
        }

        if (updateDto.Workflow != null)
        {
            user.Workflow = await _context
                .Workflows.Where(workflow =>
                    updateDto.Workflow.Select(t => t).Contains(workflow.Id)
                )
                .ToListAsync();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(e => e.Id == user.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple Account records to User
    /// </summary>
    public async Task ConnectAccount(
        UserWhereUniqueInput uniqueId,
        AccountWhereUniqueInput[] accountsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var accounts = await _context
            .Accounts.Where(t => accountsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (accounts.Count == 0)
        {
            throw new NotFoundException();
        }

        var accountsToConnect = accounts.Except(user.Account);

        foreach (var account in accountsToConnect)
        {
            user.Account.Add(account);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Api Key records to User
    /// </summary>
    public async Task ConnectApiKey(
        UserWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        var user = await _context
            .Users.Include(x => x.ApiKey)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var apiKeys = await _context
            .ApiKeys.Where(t => apiKeysId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (apiKeys.Count == 0)
        {
            throw new NotFoundException();
        }

        var apiKeysToConnect = apiKeys.Except(user.ApiKey);

        foreach (var apiKey in apiKeysToConnect)
        {
            user.ApiKey.Add(apiKey);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Availability records to User
    /// </summary>
    public async Task ConnectAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        var user = await _context
            .Users.Include(x => x.Availability)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var availabilities = await _context
            .Availabilities.Where(t => availabilitiesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (availabilities.Count == 0)
        {
            throw new NotFoundException();
        }

        var availabilitiesToConnect = availabilities.Except(user.Availability);

        foreach (var availability in availabilitiesToConnect)
        {
            user.Availability.Add(availability);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Booking records to User
    /// </summary>
    public async Task ConnectBooking(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Booking)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var bookings = await _context
            .Bookings.Where(t => bookingsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (bookings.Count == 0)
        {
            throw new NotFoundException();
        }

        var bookingsToConnect = bookings.Except(user.Booking);

        foreach (var booking in bookingsToConnect)
        {
            user.Booking.Add(booking);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Credential records to User
    /// </summary>
    public async Task ConnectCredential(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Credential)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var credentials = await _context
            .Credentials.Where(t => credentialsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (credentials.Count == 0)
        {
            throw new NotFoundException();
        }

        var credentialsToConnect = credentials.Except(user.Credential);

        foreach (var credential in credentialsToConnect)
        {
            user.Credential.Add(credential);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Event Type records to User
    /// </summary>
    public async Task ConnectEventType(
        UserWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var user = await _context
            .Users.Include(x => x.EventType)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var eventTypes = await _context
            .EventTypes.Where(t => eventTypesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (eventTypes.Count == 0)
        {
            throw new NotFoundException();
        }

        var eventTypesToConnect = eventTypes.Except(user.EventType);

        foreach (var eventType in eventTypesToConnect)
        {
            user.EventType.Add(eventType);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Feedback records to User
    /// </summary>
    public async Task ConnectFeedback(
        UserWhereUniqueInput uniqueId,
        FeedbackWhereUniqueInput[] feedbacksId
    )
    {
        var user = await _context
            .Users.Include(x => x.Feedback)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var feedbacks = await _context
            .Feedbacks.Where(t => feedbacksId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (feedbacks.Count == 0)
        {
            throw new NotFoundException();
        }

        var feedbacksToConnect = feedbacks.Except(user.Feedback);

        foreach (var feedback in feedbacksToConnect)
        {
            user.Feedback.Add(feedback);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Impersonations Impersonations Impersonated By Id Tousers records to User
    /// </summary>
    public async Task ConnectImpersonationsImpersonationsImpersonatedByIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(x => x.ImpersonationsImpersonationsImpersonatedByIdTousers)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var impersonations = await _context
            .Impersonations.Where(t => impersonationsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (impersonations.Count == 0)
        {
            throw new NotFoundException();
        }

        var impersonationsToConnect = impersonations.Except(
            user.ImpersonationsImpersonationsImpersonatedByIdTousers
        );

        foreach (var impersonation in impersonationsToConnect)
        {
            user.ImpersonationsImpersonationsImpersonatedByIdTousers.Add(impersonation);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Impersonations Impersonations Impersonated User Id Tousers records to User
    /// </summary>
    public async Task ConnectImpersonationsImpersonationsImpersonatedUserIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(x => x.ImpersonationsImpersonationsImpersonatedByIdTousers)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var impersonations = await _context
            .Impersonations.Where(t => impersonationsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (impersonations.Count == 0)
        {
            throw new NotFoundException();
        }

        var impersonationsToConnect = impersonations.Except(
            user.ImpersonationsImpersonationsImpersonatedByIdTousers
        );

        foreach (var impersonation in impersonationsToConnect)
        {
            user.ImpersonationsImpersonationsImpersonatedByIdTousers.Add(impersonation);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Membership records to User
    /// </summary>
    public async Task ConnectMembership(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Membership)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var memberships = await _context
            .Memberships.Where(t => membershipsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (memberships.Count == 0)
        {
            throw new NotFoundException();
        }

        var membershipsToConnect = memberships.Except(user.Membership);

        foreach (var membership in membershipsToConnect)
        {
            user.Membership.Add(membership);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Schedule records to User
    /// </summary>
    public async Task ConnectSchedule(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    )
    {
        var user = await _context
            .Users.Include(x => x.Schedule)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var schedules = await _context
            .Schedules.Where(t => schedulesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (schedules.Count == 0)
        {
            throw new NotFoundException();
        }

        var schedulesToConnect = schedules.Except(user.Schedule);

        foreach (var schedule in schedulesToConnect)
        {
            user.Schedule.Add(schedule);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Selected Calendar records to User
    /// </summary>
    public async Task ConnectSelectedCalendar(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        var user = await _context
            .Users.Include(x => x.SelectedCalendar)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var selectedCalendars = await _context
            .SelectedCalendars.Where(t => selectedCalendarsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (selectedCalendars.Count == 0)
        {
            throw new NotFoundException();
        }

        var selectedCalendarsToConnect = selectedCalendars.Except(user.SelectedCalendar);

        foreach (var selectedCalendar in selectedCalendarsToConnect)
        {
            user.SelectedCalendar.Add(selectedCalendar);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Session records to User
    /// </summary>
    public async Task ConnectSession(
        UserWhereUniqueInput uniqueId,
        SessionWhereUniqueInput[] sessionsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Session)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var sessions = await _context
            .Sessions.Where(t => sessionsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (sessions.Count == 0)
        {
            throw new NotFoundException();
        }

        var sessionsToConnect = sessions.Except(user.Session);

        foreach (var session in sessionsToConnect)
        {
            user.Session.Add(session);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Webhook records to User
    /// </summary>
    public async Task ConnectWebhook(
        UserWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var user = await _context
            .Users.Include(x => x.Webhook)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var webhooks = await _context
            .Webhooks.Where(t => webhooksId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (webhooks.Count == 0)
        {
            throw new NotFoundException();
        }

        var webhooksToConnect = webhooks.Except(user.Webhook);

        foreach (var webhook in webhooksToConnect)
        {
            user.Webhook.Add(webhook);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Workflow records to User
    /// </summary>
    public async Task ConnectWorkflow(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Workflow)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var workflows = await _context
            .Workflows.Where(t => workflowsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (workflows.Count == 0)
        {
            throw new NotFoundException();
        }

        var workflowsToConnect = workflows.Except(user.Workflow);

        foreach (var workflow in workflowsToConnect)
        {
            user.Workflow.Add(workflow);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Account records from User
    /// </summary>
    public async Task DisconnectAccount(
        UserWhereUniqueInput uniqueId,
        AccountWhereUniqueInput[] accountsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var accounts = await _context
            .Accounts.Where(t => accountsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var account in accounts)
        {
            user.Account?.Remove(account);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Api Key records from User
    /// </summary>
    public async Task DisconnectApiKey(
        UserWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        var user = await _context
            .Users.Include(x => x.ApiKey)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var apiKeys = await _context
            .ApiKeys.Where(t => apiKeysId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var apiKey in apiKeys)
        {
            user.ApiKey?.Remove(apiKey);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Availability records from User
    /// </summary>
    public async Task DisconnectAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        var user = await _context
            .Users.Include(x => x.Availability)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var availabilities = await _context
            .Availabilities.Where(t => availabilitiesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var availability in availabilities)
        {
            user.Availability?.Remove(availability);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Booking records from User
    /// </summary>
    public async Task DisconnectBooking(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Booking)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var bookings = await _context
            .Bookings.Where(t => bookingsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var booking in bookings)
        {
            user.Booking?.Remove(booking);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Credential records from User
    /// </summary>
    public async Task DisconnectCredential(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Credential)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var credentials = await _context
            .Credentials.Where(t => credentialsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var credential in credentials)
        {
            user.Credential?.Remove(credential);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Event Type records from User
    /// </summary>
    public async Task DisconnectEventType(
        UserWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var user = await _context
            .Users.Include(x => x.EventType)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var eventTypes = await _context
            .EventTypes.Where(t => eventTypesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var eventType in eventTypes)
        {
            user.EventType?.Remove(eventType);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Feedback records from User
    /// </summary>
    public async Task DisconnectFeedback(
        UserWhereUniqueInput uniqueId,
        FeedbackWhereUniqueInput[] feedbacksId
    )
    {
        var user = await _context
            .Users.Include(x => x.Feedback)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var feedbacks = await _context
            .Feedbacks.Where(t => feedbacksId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var feedback in feedbacks)
        {
            user.Feedback?.Remove(feedback);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Impersonations Impersonations Impersonated By Id Tousers records from User
    /// </summary>
    public async Task DisconnectImpersonationsImpersonationsImpersonatedByIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(x => x.ImpersonationsImpersonationsImpersonatedByIdTousers)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var impersonations = await _context
            .Impersonations.Where(t => impersonationsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var impersonation in impersonations)
        {
            user.ImpersonationsImpersonationsImpersonatedByIdTousers?.Remove(impersonation);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Impersonations Impersonations Impersonated User Id Tousers records from User
    /// </summary>
    public async Task DisconnectImpersonationsImpersonationsImpersonatedUserIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(x => x.ImpersonationsImpersonationsImpersonatedByIdTousers)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var impersonations = await _context
            .Impersonations.Where(t => impersonationsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var impersonation in impersonations)
        {
            user.ImpersonationsImpersonationsImpersonatedByIdTousers?.Remove(impersonation);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Membership records from User
    /// </summary>
    public async Task DisconnectMembership(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Membership)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var memberships = await _context
            .Memberships.Where(t => membershipsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var membership in memberships)
        {
            user.Membership?.Remove(membership);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Schedule records from User
    /// </summary>
    public async Task DisconnectSchedule(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    )
    {
        var user = await _context
            .Users.Include(x => x.Schedule)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var schedules = await _context
            .Schedules.Where(t => schedulesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var schedule in schedules)
        {
            user.Schedule?.Remove(schedule);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Selected Calendar records from User
    /// </summary>
    public async Task DisconnectSelectedCalendar(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        var user = await _context
            .Users.Include(x => x.SelectedCalendar)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var selectedCalendars = await _context
            .SelectedCalendars.Where(t => selectedCalendarsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var selectedCalendar in selectedCalendars)
        {
            user.SelectedCalendar?.Remove(selectedCalendar);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Session records from User
    /// </summary>
    public async Task DisconnectSession(
        UserWhereUniqueInput uniqueId,
        SessionWhereUniqueInput[] sessionsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Session)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var sessions = await _context
            .Sessions.Where(t => sessionsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var session in sessions)
        {
            user.Session?.Remove(session);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Webhook records from User
    /// </summary>
    public async Task DisconnectWebhook(
        UserWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var user = await _context
            .Users.Include(x => x.Webhook)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var webhooks = await _context
            .Webhooks.Where(t => webhooksId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var webhook in webhooks)
        {
            user.Webhook?.Remove(webhook);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Workflow records from User
    /// </summary>
    public async Task DisconnectWorkflow(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Workflow)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var workflows = await _context
            .Workflows.Where(t => workflowsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var workflow in workflows)
        {
            user.Workflow?.Remove(workflow);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Account records for User
    /// </summary>
    public async Task<List<Account>> FindAccount(
        UserWhereUniqueInput uniqueId,
        AccountFindManyArgs userFindManyArgs
    )
    {
        var accounts = await _context
            .Accounts.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return accounts.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Api Key records for User
    /// </summary>
    public async Task<List<ApiKey>> FindApiKey(
        UserWhereUniqueInput uniqueId,
        ApiKeyFindManyArgs userFindManyArgs
    )
    {
        var apiKeys = await _context
            .ApiKeys.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return apiKeys.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Availability records for User
    /// </summary>
    public async Task<List<Availability>> FindAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityFindManyArgs userFindManyArgs
    )
    {
        var availabilities = await _context
            .Availabilities.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return availabilities.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Booking records for User
    /// </summary>
    public async Task<List<Booking>> FindBooking(
        UserWhereUniqueInput uniqueId,
        BookingFindManyArgs userFindManyArgs
    )
    {
        var bookings = await _context
            .Bookings.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return bookings.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Credential records for User
    /// </summary>
    public async Task<List<Credential>> FindCredential(
        UserWhereUniqueInput uniqueId,
        CredentialFindManyArgs userFindManyArgs
    )
    {
        var credentials = await _context
            .Credentials.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return credentials.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Event Type records for User
    /// </summary>
    public async Task<List<EventType>> FindEventType(
        UserWhereUniqueInput uniqueId,
        EventTypeFindManyArgs userFindManyArgs
    )
    {
        var eventTypes = await _context
            .EventTypes.Where(m => m.Users.Any(x => x.Id == uniqueId.Id))
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return eventTypes.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Feedback records for User
    /// </summary>
    public async Task<List<Feedback>> FindFeedback(
        UserWhereUniqueInput uniqueId,
        FeedbackFindManyArgs userFindManyArgs
    )
    {
        var feedbacks = await _context
            .Feedbacks.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return feedbacks.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Impersonations Impersonations Impersonated By Id Tousers records for User
    /// </summary>
    public async Task<List<Impersonation>> FindImpersonationsImpersonationsImpersonatedByIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationFindManyArgs userFindManyArgs
    )
    {
        var impersonations = await _context
            .Impersonations.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return impersonations.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Impersonations Impersonations Impersonated User Id Tousers records for User
    /// </summary>
    public async Task<
        List<Impersonation>
    > FindImpersonationsImpersonationsImpersonatedUserIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationFindManyArgs userFindManyArgs
    )
    {
        var impersonations = await _context
            .Impersonations.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return impersonations.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Membership records for User
    /// </summary>
    public async Task<List<Membership>> FindMembership(
        UserWhereUniqueInput uniqueId,
        MembershipFindManyArgs userFindManyArgs
    )
    {
        var memberships = await _context
            .Memberships.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return memberships.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Schedule records for User
    /// </summary>
    public async Task<List<Schedule>> FindSchedule(
        UserWhereUniqueInput uniqueId,
        ScheduleFindManyArgs userFindManyArgs
    )
    {
        var schedules = await _context
            .Schedules.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return schedules.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Selected Calendar records for User
    /// </summary>
    public async Task<List<SelectedCalendar>> FindSelectedCalendar(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarFindManyArgs userFindManyArgs
    )
    {
        var selectedCalendars = await _context
            .SelectedCalendars.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return selectedCalendars.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Session records for User
    /// </summary>
    public async Task<List<Session>> FindSession(
        UserWhereUniqueInput uniqueId,
        SessionFindManyArgs userFindManyArgs
    )
    {
        var sessions = await _context
            .Sessions.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return sessions.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Webhook records for User
    /// </summary>
    public async Task<List<Webhook>> FindWebhook(
        UserWhereUniqueInput uniqueId,
        WebhookFindManyArgs userFindManyArgs
    )
    {
        var webhooks = await _context
            .Webhooks.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return webhooks.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Workflow records for User
    /// </summary>
    public async Task<List<Workflow>> FindWorkflow(
        UserWhereUniqueInput uniqueId,
        WorkflowFindManyArgs userFindManyArgs
    )
    {
        var workflows = await _context
            .Workflows.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return workflows.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Get a Destination Calendar record for User
    /// </summary>
    public async Task<DestinationCalendar> GetDestinationCalendar(UserWhereUniqueInput uniqueId)
    {
        var user = await _context
            .Users.Where(user => user.Id == uniqueId.Id)
            .Include(user => user.DestinationCalendar)
            .FirstOrDefaultAsync();
        if (user == null)
        {
            throw new NotFoundException();
        }
        return user.DestinationCalendar.ToDto();
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public async Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs)
    {
        var count = await _context.Users.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Account records for User
    /// </summary>
    public async Task UpdateAccount(
        UserWhereUniqueInput uniqueId,
        AccountWhereUniqueInput[] accountsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Account)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var accounts = await _context
            .Accounts.Where(a => accountsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (accounts.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Account = accounts;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Api Key records for User
    /// </summary>
    public async Task UpdateApiKey(
        UserWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        var user = await _context
            .Users.Include(t => t.ApiKey)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var apiKeys = await _context
            .ApiKeys.Where(a => apiKeysId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (apiKeys.Count == 0)
        {
            throw new NotFoundException();
        }

        user.ApiKey = apiKeys;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Availability records for User
    /// </summary>
    public async Task UpdateAvailability(
        UserWhereUniqueInput uniqueId,
        AvailabilityWhereUniqueInput[] availabilitiesId
    )
    {
        var user = await _context
            .Users.Include(t => t.Availability)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var availabilities = await _context
            .Availabilities.Where(a => availabilitiesId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (availabilities.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Availability = availabilities;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Booking records for User
    /// </summary>
    public async Task UpdateBooking(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Booking)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var bookings = await _context
            .Bookings.Where(a => bookingsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (bookings.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Booking = bookings;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Credential records for User
    /// </summary>
    public async Task UpdateCredential(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Credential)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var credentials = await _context
            .Credentials.Where(a => credentialsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (credentials.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Credential = credentials;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Event Type records for User
    /// </summary>
    public async Task UpdateEventType(
        UserWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var user = await _context
            .Users.Include(t => t.EventType)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var eventTypes = await _context
            .EventTypes.Where(a => eventTypesId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (eventTypes.Count == 0)
        {
            throw new NotFoundException();
        }

        user.EventType = eventTypes;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Feedback records for User
    /// </summary>
    public async Task UpdateFeedback(
        UserWhereUniqueInput uniqueId,
        FeedbackWhereUniqueInput[] feedbacksId
    )
    {
        var user = await _context
            .Users.Include(t => t.Feedback)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var feedbacks = await _context
            .Feedbacks.Where(a => feedbacksId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (feedbacks.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Feedback = feedbacks;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Impersonations Impersonations Impersonated By Id Tousers records for User
    /// </summary>
    public async Task UpdateImpersonationsImpersonationsImpersonatedByIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(t => t.ImpersonationsImpersonationsImpersonatedByIdTousers)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var impersonations = await _context
            .Impersonations.Where(a => impersonationsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (impersonations.Count == 0)
        {
            throw new NotFoundException();
        }

        user.ImpersonationsImpersonationsImpersonatedByIdTousers = impersonations;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Impersonations Impersonations Impersonated User Id Tousers records for User
    /// </summary>
    public async Task UpdateImpersonationsImpersonationsImpersonatedUserIdTousers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(t => t.ImpersonationsImpersonationsImpersonatedByIdTousers)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var impersonations = await _context
            .Impersonations.Where(a => impersonationsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (impersonations.Count == 0)
        {
            throw new NotFoundException();
        }

        user.ImpersonationsImpersonationsImpersonatedByIdTousers = impersonations;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Membership records for User
    /// </summary>
    public async Task UpdateMembership(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Membership)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var memberships = await _context
            .Memberships.Where(a => membershipsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (memberships.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Membership = memberships;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Schedule records for User
    /// </summary>
    public async Task UpdateSchedule(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    )
    {
        var user = await _context
            .Users.Include(t => t.Schedule)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var schedules = await _context
            .Schedules.Where(a => schedulesId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (schedules.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Schedule = schedules;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Selected Calendar records for User
    /// </summary>
    public async Task UpdateSelectedCalendar(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        var user = await _context
            .Users.Include(t => t.SelectedCalendar)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var selectedCalendars = await _context
            .SelectedCalendars.Where(a => selectedCalendarsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (selectedCalendars.Count == 0)
        {
            throw new NotFoundException();
        }

        user.SelectedCalendar = selectedCalendars;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Session records for User
    /// </summary>
    public async Task UpdateSession(
        UserWhereUniqueInput uniqueId,
        SessionWhereUniqueInput[] sessionsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Session)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var sessions = await _context
            .Sessions.Where(a => sessionsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (sessions.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Session = sessions;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Webhook records for User
    /// </summary>
    public async Task UpdateWebhook(
        UserWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var user = await _context
            .Users.Include(t => t.Webhook)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var webhooks = await _context
            .Webhooks.Where(a => webhooksId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (webhooks.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Webhook = webhooks;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Workflow records for User
    /// </summary>
    public async Task UpdateWorkflow(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Workflow)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var workflows = await _context
            .Workflows.Where(a => workflowsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (workflows.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Workflow = workflows;
        await _context.SaveChangesAsync();
    }
}
