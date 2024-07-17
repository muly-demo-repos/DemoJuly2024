using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class SelectedCalendarsExtensions
{
    public static SelectedCalendar ToDto(this SelectedCalendarDbModel model)
    {
        return new SelectedCalendar
        {
            Id = model.Id,
            User = model.UserId,
            Integration = model.Integration,
            ExternalId = model.ExternalId,
        };
    }

    public static SelectedCalendarDbModel ToModel(
        this SelectedCalendarUpdateInput updateDto,
        SelectedCalendarWhereUniqueInput uniqueId
    )
    {
        var selectedCalendar = new SelectedCalendarDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.User != null)
        {
            selectedCalendar.User = updateDto.User.Value;
        }
        if (updateDto.Integration != null)
        {
            selectedCalendar.Integration = updateDto.Integration;
        }
        if (updateDto.ExternalId != null)
        {
            selectedCalendar.ExternalId = updateDto.ExternalId;
        }

        return selectedCalendar;
    }
}
