using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class UsersServiceBase : IUsersService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public UsersServiceBase(CactusDemoDotnetDbContext context)
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
            CreatedDate = createDto.CreatedDate,
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
        if (createDto.EventTypes != null)
        {
            user.EventTypes = await _context
                .EventTypes.Where(eventType =>
                    createDto.EventTypes.Select(t => t.Id).Contains(eventType.Id)
                )
                .ToListAsync();
        }

        if (createDto.Credentials != null)
        {
            user.Credentials = await _context
                .Credentials.Where(credential =>
                    createDto.Credentials.Select(t => t.Id).Contains(credential.Id)
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

        if (createDto.Teams != null)
        {
            user.Teams = await _context
                .Memberships.Where(membership =>
                    createDto.Teams.Select(t => t.Id).Contains(membership.Id)
                )
                .ToListAsync();
        }

        if (createDto.Bookings != null)
        {
            user.Bookings = await _context
                .Bookings.Where(booking =>
                    createDto.Bookings.Select(t => t.Id).Contains(booking.Id)
                )
                .ToListAsync();
        }

        if (createDto.Schedules != null)
        {
            user.Schedules = await _context
                .Schedules.Where(schedule =>
                    createDto.Schedules.Select(t => t.Id).Contains(schedule.Id)
                )
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

        if (createDto.SelectedCalendars != null)
        {
            user.SelectedCalendars = await _context
                .SelectedCalendars.Where(selectedCalendar =>
                    createDto.SelectedCalendars.Select(t => t.Id).Contains(selectedCalendar.Id)
                )
                .ToListAsync();
        }

        if (createDto.Webhooks != null)
        {
            user.Webhooks = await _context
                .Webhooks.Where(webhook =>
                    createDto.Webhooks.Select(t => t.Id).Contains(webhook.Id)
                )
                .ToListAsync();
        }

        if (createDto.ImpersonatedUsers != null)
        {
            user.ImpersonatedUsers = await _context
                .Impersonations.Where(impersonation =>
                    createDto.ImpersonatedUsers.Select(t => t.Id).Contains(impersonation.Id)
                )
                .ToListAsync();
        }

        if (createDto.ApiKeys != null)
        {
            user.ApiKeys = await _context
                .ApiKeys.Where(apiKey => createDto.ApiKeys.Select(t => t.Id).Contains(apiKey.Id))
                .ToListAsync();
        }

        if (createDto.Accounts != null)
        {
            user.Accounts = await _context
                .Accounts.Where(account =>
                    createDto.Accounts.Select(t => t.Id).Contains(account.Id)
                )
                .ToListAsync();
        }

        if (createDto.Sessions != null)
        {
            user.Sessions = await _context
                .Sessions.Where(session =>
                    createDto.Sessions.Select(t => t.Id).Contains(session.Id)
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

        if (createDto.Workflows != null)
        {
            user.Workflows = await _context
                .Workflows.Where(workflow =>
                    createDto.Workflows.Select(t => t.Id).Contains(workflow.Id)
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
            .Users.Include(x => x.EventTypes)
            .Include(x => x.Credentials)
            .Include(x => x.DestinationCalendar)
            .Include(x => x.Teams)
            .Include(x => x.Bookings)
            .Include(x => x.Schedules)
            .Include(x => x.Availability)
            .Include(x => x.SelectedCalendars)
            .Include(x => x.Webhooks)
            .Include(x => x.ImpersonatedUsers)
            .Include(x => x.ApiKeys)
            .Include(x => x.Accounts)
            .Include(x => x.Sessions)
            .Include(x => x.Feedback)
            .Include(x => x.Workflows)
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

        if (updateDto.EventTypes != null)
        {
            user.EventTypes = await _context
                .EventTypes.Where(eventType =>
                    updateDto.EventTypes.Select(t => t).Contains(eventType.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Credentials != null)
        {
            user.Credentials = await _context
                .Credentials.Where(credential =>
                    updateDto.Credentials.Select(t => t).Contains(credential.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Teams != null)
        {
            user.Teams = await _context
                .Memberships.Where(membership =>
                    updateDto.Teams.Select(t => t).Contains(membership.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Bookings != null)
        {
            user.Bookings = await _context
                .Bookings.Where(booking => updateDto.Bookings.Select(t => t).Contains(booking.Id))
                .ToListAsync();
        }

        if (updateDto.Schedules != null)
        {
            user.Schedules = await _context
                .Schedules.Where(schedule =>
                    updateDto.Schedules.Select(t => t).Contains(schedule.Id)
                )
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

        if (updateDto.SelectedCalendars != null)
        {
            user.SelectedCalendars = await _context
                .SelectedCalendars.Where(selectedCalendar =>
                    updateDto.SelectedCalendars.Select(t => t).Contains(selectedCalendar.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Webhooks != null)
        {
            user.Webhooks = await _context
                .Webhooks.Where(webhook => updateDto.Webhooks.Select(t => t).Contains(webhook.Id))
                .ToListAsync();
        }

        if (updateDto.ImpersonatedUsers != null)
        {
            user.ImpersonatedUsers = await _context
                .Impersonations.Where(impersonation =>
                    updateDto.ImpersonatedUsers.Select(t => t).Contains(impersonation.Id)
                )
                .ToListAsync();
        }

        if (updateDto.ApiKeys != null)
        {
            user.ApiKeys = await _context
                .ApiKeys.Where(apiKey => updateDto.ApiKeys.Select(t => t).Contains(apiKey.Id))
                .ToListAsync();
        }

        if (updateDto.Accounts != null)
        {
            user.Accounts = await _context
                .Accounts.Where(account => updateDto.Accounts.Select(t => t).Contains(account.Id))
                .ToListAsync();
        }

        if (updateDto.Sessions != null)
        {
            user.Sessions = await _context
                .Sessions.Where(session => updateDto.Sessions.Select(t => t).Contains(session.Id))
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

        if (updateDto.Workflows != null)
        {
            user.Workflows = await _context
                .Workflows.Where(workflow =>
                    updateDto.Workflows.Select(t => t).Contains(workflow.Id)
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
    /// Connect multiple Accounts records to User
    /// </summary>
    public async Task ConnectAccounts(
        UserWhereUniqueInput uniqueId,
        AccountWhereUniqueInput[] accountsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Accounts)
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

        var accountsToConnect = accounts.Except(user.Accounts);

        foreach (var account in accountsToConnect)
        {
            user.Accounts.Add(account);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Api Keys records to User
    /// </summary>
    public async Task ConnectApiKeys(
        UserWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        var user = await _context
            .Users.Include(x => x.ApiKeys)
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

        var apiKeysToConnect = apiKeys.Except(user.ApiKeys);

        foreach (var apiKey in apiKeysToConnect)
        {
            user.ApiKeys.Add(apiKey);
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
    /// Connect multiple Bookings records to User
    /// </summary>
    public async Task ConnectBookings(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Bookings)
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

        var bookingsToConnect = bookings.Except(user.Bookings);

        foreach (var booking in bookingsToConnect)
        {
            user.Bookings.Add(booking);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Credentials records to User
    /// </summary>
    public async Task ConnectCredentials(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Credentials)
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

        var credentialsToConnect = credentials.Except(user.Credentials);

        foreach (var credential in credentialsToConnect)
        {
            user.Credentials.Add(credential);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Event Types records to User
    /// </summary>
    public async Task ConnectEventTypes(
        UserWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var user = await _context
            .Users.Include(x => x.EventTypes)
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

        var eventTypesToConnect = eventTypes.Except(user.EventTypes);

        foreach (var eventType in eventTypesToConnect)
        {
            user.EventTypes.Add(eventType);
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
    /// Connect multiple Impersonated By records to User
    /// </summary>
    public async Task ConnectImpersonatedBy(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(x => x.ImpersonatedUsers)
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

        var impersonationsToConnect = impersonations.Except(user.ImpersonatedUsers);

        foreach (var impersonation in impersonationsToConnect)
        {
            user.ImpersonatedUsers.Add(impersonation);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Impersonated Users records to User
    /// </summary>
    public async Task ConnectImpersonatedUsers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(x => x.ImpersonatedUsers)
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

        var impersonationsToConnect = impersonations.Except(user.ImpersonatedUsers);

        foreach (var impersonation in impersonationsToConnect)
        {
            user.ImpersonatedUsers.Add(impersonation);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Schedules records to User
    /// </summary>
    public async Task ConnectSchedules(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    )
    {
        var user = await _context
            .Users.Include(x => x.Schedules)
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

        var schedulesToConnect = schedules.Except(user.Schedules);

        foreach (var schedule in schedulesToConnect)
        {
            user.Schedules.Add(schedule);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Selected Calendars records to User
    /// </summary>
    public async Task ConnectSelectedCalendars(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        var user = await _context
            .Users.Include(x => x.SelectedCalendars)
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

        var selectedCalendarsToConnect = selectedCalendars.Except(user.SelectedCalendars);

        foreach (var selectedCalendar in selectedCalendarsToConnect)
        {
            user.SelectedCalendars.Add(selectedCalendar);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Sessions records to User
    /// </summary>
    public async Task ConnectSessions(
        UserWhereUniqueInput uniqueId,
        SessionWhereUniqueInput[] sessionsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Sessions)
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

        var sessionsToConnect = sessions.Except(user.Sessions);

        foreach (var session in sessionsToConnect)
        {
            user.Sessions.Add(session);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Teams records to User
    /// </summary>
    public async Task ConnectTeams(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Teams)
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

        var membershipsToConnect = memberships.Except(user.Teams);

        foreach (var membership in membershipsToConnect)
        {
            user.Teams.Add(membership);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Webhooks records to User
    /// </summary>
    public async Task ConnectWebhooks(
        UserWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var user = await _context
            .Users.Include(x => x.Webhooks)
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

        var webhooksToConnect = webhooks.Except(user.Webhooks);

        foreach (var webhook in webhooksToConnect)
        {
            user.Webhooks.Add(webhook);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Workflows records to User
    /// </summary>
    public async Task ConnectWorkflows(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Workflows)
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

        var workflowsToConnect = workflows.Except(user.Workflows);

        foreach (var workflow in workflowsToConnect)
        {
            user.Workflows.Add(workflow);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Accounts records from User
    /// </summary>
    public async Task DisconnectAccounts(
        UserWhereUniqueInput uniqueId,
        AccountWhereUniqueInput[] accountsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Accounts)
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
            user.Accounts?.Remove(account);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Api Keys records from User
    /// </summary>
    public async Task DisconnectApiKeys(
        UserWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        var user = await _context
            .Users.Include(x => x.ApiKeys)
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
            user.ApiKeys?.Remove(apiKey);
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
    /// Disconnect multiple Bookings records from User
    /// </summary>
    public async Task DisconnectBookings(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Bookings)
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
            user.Bookings?.Remove(booking);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Credentials records from User
    /// </summary>
    public async Task DisconnectCredentials(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Credentials)
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
            user.Credentials?.Remove(credential);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Event Types records from User
    /// </summary>
    public async Task DisconnectEventTypes(
        UserWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var user = await _context
            .Users.Include(x => x.EventTypes)
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
            user.EventTypes?.Remove(eventType);
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
    /// Disconnect multiple Impersonated By records from User
    /// </summary>
    public async Task DisconnectImpersonatedBy(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(x => x.ImpersonatedUsers)
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
            user.ImpersonatedUsers?.Remove(impersonation);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Impersonated Users records from User
    /// </summary>
    public async Task DisconnectImpersonatedUsers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(x => x.ImpersonatedUsers)
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
            user.ImpersonatedUsers?.Remove(impersonation);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Schedules records from User
    /// </summary>
    public async Task DisconnectSchedules(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    )
    {
        var user = await _context
            .Users.Include(x => x.Schedules)
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
            user.Schedules?.Remove(schedule);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Selected Calendars records from User
    /// </summary>
    public async Task DisconnectSelectedCalendars(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        var user = await _context
            .Users.Include(x => x.SelectedCalendars)
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
            user.SelectedCalendars?.Remove(selectedCalendar);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Sessions records from User
    /// </summary>
    public async Task DisconnectSessions(
        UserWhereUniqueInput uniqueId,
        SessionWhereUniqueInput[] sessionsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Sessions)
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
            user.Sessions?.Remove(session);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Teams records from User
    /// </summary>
    public async Task DisconnectTeams(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Teams)
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
            user.Teams?.Remove(membership);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Webhooks records from User
    /// </summary>
    public async Task DisconnectWebhooks(
        UserWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var user = await _context
            .Users.Include(x => x.Webhooks)
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
            user.Webhooks?.Remove(webhook);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Workflows records from User
    /// </summary>
    public async Task DisconnectWorkflows(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    )
    {
        var user = await _context
            .Users.Include(x => x.Workflows)
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
            user.Workflows?.Remove(workflow);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Accounts records for User
    /// </summary>
    public async Task<List<Account>> FindAccounts(
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
    /// Find multiple Api Keys records for User
    /// </summary>
    public async Task<List<ApiKey>> FindApiKeys(
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
    /// Find multiple Bookings records for User
    /// </summary>
    public async Task<List<Booking>> FindBookings(
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
    /// Find multiple Credentials records for User
    /// </summary>
    public async Task<List<Credential>> FindCredentials(
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
    /// Find multiple Event Types records for User
    /// </summary>
    public async Task<List<EventType>> FindEventTypes(
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
    /// Find multiple Impersonated By records for User
    /// </summary>
    public async Task<List<Impersonation>> FindImpersonatedBy(
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
    /// Find multiple Impersonated Users records for User
    /// </summary>
    public async Task<List<Impersonation>> FindImpersonatedUsers(
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
    /// Find multiple Schedules records for User
    /// </summary>
    public async Task<List<Schedule>> FindSchedules(
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
    /// Find multiple Selected Calendars records for User
    /// </summary>
    public async Task<List<SelectedCalendar>> FindSelectedCalendars(
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
    /// Find multiple Sessions records for User
    /// </summary>
    public async Task<List<Session>> FindSessions(
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
    /// Find multiple Teams records for User
    /// </summary>
    public async Task<List<Membership>> FindTeams(
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
    /// Find multiple Webhooks records for User
    /// </summary>
    public async Task<List<Webhook>> FindWebhooks(
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
    /// Find multiple Workflows records for User
    /// </summary>
    public async Task<List<Workflow>> FindWorkflows(
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
    /// Update multiple Accounts records for User
    /// </summary>
    public async Task UpdateAccounts(
        UserWhereUniqueInput uniqueId,
        AccountWhereUniqueInput[] accountsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Accounts)
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

        user.Accounts = accounts;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Api Keys records for User
    /// </summary>
    public async Task UpdateApiKeys(
        UserWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        var user = await _context
            .Users.Include(t => t.ApiKeys)
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

        user.ApiKeys = apiKeys;
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
    /// Update multiple Bookings records for User
    /// </summary>
    public async Task UpdateBookings(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Bookings)
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

        user.Bookings = bookings;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Credentials records for User
    /// </summary>
    public async Task UpdateCredentials(
        UserWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Credentials)
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

        user.Credentials = credentials;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Event Types records for User
    /// </summary>
    public async Task UpdateEventTypes(
        UserWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var user = await _context
            .Users.Include(t => t.EventTypes)
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

        user.EventTypes = eventTypes;
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
    /// Update multiple Impersonated By records for User
    /// </summary>
    public async Task UpdateImpersonatedBy(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(t => t.ImpersonatedUsers)
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

        user.ImpersonatedUsers = impersonations;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Impersonated Users records for User
    /// </summary>
    public async Task UpdateImpersonatedUsers(
        UserWhereUniqueInput uniqueId,
        ImpersonationWhereUniqueInput[] impersonationsId
    )
    {
        var user = await _context
            .Users.Include(t => t.ImpersonatedUsers)
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

        user.ImpersonatedUsers = impersonations;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Schedules records for User
    /// </summary>
    public async Task UpdateSchedules(
        UserWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    )
    {
        var user = await _context
            .Users.Include(t => t.Schedules)
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

        user.Schedules = schedules;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Selected Calendars records for User
    /// </summary>
    public async Task UpdateSelectedCalendars(
        UserWhereUniqueInput uniqueId,
        SelectedCalendarWhereUniqueInput[] selectedCalendarsId
    )
    {
        var user = await _context
            .Users.Include(t => t.SelectedCalendars)
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

        user.SelectedCalendars = selectedCalendars;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Sessions records for User
    /// </summary>
    public async Task UpdateSessions(
        UserWhereUniqueInput uniqueId,
        SessionWhereUniqueInput[] sessionsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Sessions)
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

        user.Sessions = sessions;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Teams records for User
    /// </summary>
    public async Task UpdateTeams(
        UserWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Teams)
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

        user.Teams = memberships;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Webhooks records for User
    /// </summary>
    public async Task UpdateWebhooks(
        UserWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var user = await _context
            .Users.Include(t => t.Webhooks)
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

        user.Webhooks = webhooks;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Workflows records for User
    /// </summary>
    public async Task UpdateWorkflows(
        UserWhereUniqueInput uniqueId,
        WorkflowWhereUniqueInput[] workflowsId
    )
    {
        var user = await _context
            .Users.Include(t => t.Workflows)
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

        user.Workflows = workflows;
        await _context.SaveChangesAsync();
    }
}
