using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class UsersExtensions
{
    public static User ToDto(this UserDbModel model)
    {
        return new User
        {
            Id = model.Id,
            Username = model.Username,
            Name = model.Name,
            Email = model.Email,
            EmailVerified = model.EmailVerified,
            Password = model.Password,
            Bio = model.Bio,
            Avatar = model.Avatar,
            TimeZone = model.TimeZone,
            WeekStart = model.WeekStart,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            BufferTime = model.BufferTime,
            HideBranding = model.HideBranding,
            Theme = model.Theme,
            Created = model.Created,
            TrialEndsAt = model.TrialEndsAt,
            DefaultScheduleId = model.DefaultScheduleId,
            CompletedOnboarding = model.CompletedOnboarding,
            Locale = model.Locale,
            TimeFormat = model.TimeFormat,
            TwoFactorSecret = model.TwoFactorSecret,
            TwoFactorEnabled = model.TwoFactorEnabled,
            IdentityProvider = model.IdentityProvider,
            IdentityProviderId = model.IdentityProviderId,
            InvitedTo = model.InvitedTo,
            Plan = model.Plan,
            BrandColor = model.BrandColor,
            DarkBrandColor = model.DarkBrandColor,
            Away = model.Away,
            AllowDynamicBooking = model.AllowDynamicBooking,
            Metadata = model.Metadata,
            Verified = model.Verified,
            Role = model.Role,
            DisableImpersonation = model.DisableImpersonation,
            Account = model.Account?.Select(x => x.Id).ToList(),
            ApiKey = model.ApiKey?.Select(x => x.Id).ToList(),
            Availability = model.Availability?.Select(x => x.Id).ToList(),
            Booking = model.Booking?.Select(x => x.Id).ToList(),
            Credential = model.Credential?.Select(x => x.Id).ToList(),
            DestinationCalendar = model.DestinationCalendar?.ToDto(),
            EventType = model.EventType?.Select(x => x.Id).ToList(),
            Feedback = model.Feedback?.Select(x => x.Id).ToList(),
            ImpersonationsImpersonationsImpersonatedByIdTousers = model
                .ImpersonationsImpersonationsImpersonatedByIdTousers?.Select(x => x.Id)
                .ToList(),
            ImpersonationsImpersonationsImpersonatedUserIdTousers = model
                .ImpersonationsImpersonationsImpersonatedByIdTousers?.Select(x => x.Id)
                .ToList(),
            Membership = model.Membership?.Select(x => x.Id).ToList(),
            Schedule = model.Schedule?.Select(x => x.Id).ToList(),
            SelectedCalendar = model.SelectedCalendar?.Select(x => x.Id).ToList(),
            Session = model.Session?.Select(x => x.Id).ToList(),
            Webhook = model.Webhook?.Select(x => x.Id).ToList(),
            Workflow = model.Workflow?.Select(x => x.Id).ToList(),
        };
    }

    public static UserDbModel ToModel(this UserUpdateInput updateDto, UserWhereUniqueInput uniqueId)
    {
        var user = new UserDbModel
        {
            Id = uniqueId.Id,
            Username = updateDto.Username,
            Name = updateDto.Name,
            EmailVerified = updateDto.EmailVerified,
            Password = updateDto.Password,
            Bio = updateDto.Bio,
            Avatar = updateDto.Avatar,
            Theme = updateDto.Theme,
            TrialEndsAt = updateDto.TrialEndsAt,
            DefaultScheduleId = updateDto.DefaultScheduleId,
            Locale = updateDto.Locale,
            TimeFormat = updateDto.TimeFormat,
            TwoFactorSecret = updateDto.TwoFactorSecret,
            IdentityProviderId = updateDto.IdentityProviderId,
            InvitedTo = updateDto.InvitedTo,
            AllowDynamicBooking = updateDto.AllowDynamicBooking,
            Metadata = updateDto.Metadata,
            Verified = updateDto.Verified
        };

        // map required fields
        if (updateDto.Email != null)
        {
            user.Email = updateDto.Email;
        }
        if (updateDto.TimeZone != null)
        {
            user.TimeZone = updateDto.TimeZone;
        }
        if (updateDto.WeekStart != null)
        {
            user.WeekStart = updateDto.WeekStart;
        }
        if (updateDto.StartTime != null)
        {
            user.StartTime = updateDto.StartTime.Value;
        }
        if (updateDto.EndTime != null)
        {
            user.EndTime = updateDto.EndTime.Value;
        }
        if (updateDto.BufferTime != null)
        {
            user.BufferTime = updateDto.BufferTime.Value;
        }
        if (updateDto.HideBranding != null)
        {
            user.HideBranding = updateDto.HideBranding.Value;
        }
        if (updateDto.Created != null)
        {
            user.Created = updateDto.Created.Value;
        }
        if (updateDto.CompletedOnboarding != null)
        {
            user.CompletedOnboarding = updateDto.CompletedOnboarding.Value;
        }
        if (updateDto.TwoFactorEnabled != null)
        {
            user.TwoFactorEnabled = updateDto.TwoFactorEnabled.Value;
        }
        if (updateDto.IdentityProvider != null)
        {
            user.IdentityProvider = updateDto.IdentityProvider.Value;
        }
        if (updateDto.Plan != null)
        {
            user.Plan = updateDto.Plan.Value;
        }
        if (updateDto.BrandColor != null)
        {
            user.BrandColor = updateDto.BrandColor;
        }
        if (updateDto.DarkBrandColor != null)
        {
            user.DarkBrandColor = updateDto.DarkBrandColor;
        }
        if (updateDto.Away != null)
        {
            user.Away = updateDto.Away.Value;
        }
        if (updateDto.Role != null)
        {
            user.Role = updateDto.Role.Value;
        }
        if (updateDto.DisableImpersonation != null)
        {
            user.DisableImpersonation = updateDto.DisableImpersonation.Value;
        }

        return user;
    }
}
