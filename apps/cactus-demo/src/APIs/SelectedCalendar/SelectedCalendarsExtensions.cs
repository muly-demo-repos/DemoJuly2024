using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class SelectedCalendarsExtensions
{
    public static SelectedCalendar ToDto(this SelectedCalendarDbModel model)
    {
        return new SelectedCalendar
        {
            Id = model.Id,
            Integration = model.Integration,
            ExternalId = model.ExternalId,
            Users = model.UsersId,
        };
    }

    public static SelectedCalendarDbModel ToModel(
        this SelectedCalendarUpdateInput updateDto,
        SelectedCalendarWhereUniqueInput uniqueId
    )
    {
        var selectedCalendar = new SelectedCalendarDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.Integration != null)
        {
            selectedCalendar.Integration = updateDto.Integration;
        }
        if (updateDto.ExternalId != null)
        {
            selectedCalendar.ExternalId = updateDto.ExternalId;
        }
        if (updateDto.Users != null)
        {
            selectedCalendar.Users = updateDto.Users.Value;
        }

        return selectedCalendar;
    }
}
