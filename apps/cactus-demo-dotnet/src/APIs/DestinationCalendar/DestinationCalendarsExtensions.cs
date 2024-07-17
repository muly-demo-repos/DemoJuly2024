using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class DestinationCalendarsExtensions
{
    public static DestinationCalendar ToDto(this DestinationCalendarDbModel model)
    {
        return new DestinationCalendar
        {
            Id = model.Id,
            Integration = model.Integration,
            ExternalId = model.ExternalId,
            User = model.UserId,
            Booking = model.BookingId,
            EventType = model.EventTypeId,
            Credential = model.CredentialId,
        };
    }

    public static DestinationCalendarDbModel ToModel(
        this DestinationCalendarUpdateInput updateDto,
        DestinationCalendarWhereUniqueInput uniqueId
    )
    {
        var destinationCalendar = new DestinationCalendarDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.Integration != null)
        {
            destinationCalendar.Integration = updateDto.Integration;
        }
        if (updateDto.ExternalId != null)
        {
            destinationCalendar.ExternalId = updateDto.ExternalId;
        }

        return destinationCalendar;
    }
}
