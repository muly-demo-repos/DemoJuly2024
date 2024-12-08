using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class AttendeesExtensions
{
    public static Attendee ToDto(this AttendeeDbModel model)
    {
        return new Attendee
        {
            Id = model.Id,
            Email = model.Email,
            Name = model.Name,
            TimeZone = model.TimeZone,
            Locale = model.Locale,
            Booking = model.BookingId,
        };
    }

    public static AttendeeDbModel ToModel(
        this AttendeeUpdateInput updateDto,
        AttendeeWhereUniqueInput uniqueId
    )
    {
        var attendee = new AttendeeDbModel { Id = uniqueId.Id, Locale = updateDto.Locale };

        // map required fields
        if (updateDto.Email != null)
        {
            attendee.Email = updateDto.Email;
        }
        if (updateDto.Name != null)
        {
            attendee.Name = updateDto.Name;
        }
        if (updateDto.TimeZone != null)
        {
            attendee.TimeZone = updateDto.TimeZone;
        }

        return attendee;
    }
}
