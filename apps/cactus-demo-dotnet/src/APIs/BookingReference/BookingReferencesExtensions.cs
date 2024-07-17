using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class BookingReferencesExtensions
{
    public static BookingReference ToDto(this BookingReferenceDbModel model)
    {
        return new BookingReference
        {
            Id = model.Id,
            TypeField = model.TypeField,
            Uid = model.Uid,
            MeetingId = model.MeetingId,
            MeetingPassword = model.MeetingPassword,
            MeetingUrl = model.MeetingUrl,
            Booking = model.BookingId,
            ExternalCalendarId = model.ExternalCalendarId,
            Deleted = model.Deleted,
        };
    }

    public static BookingReferenceDbModel ToModel(
        this BookingReferenceUpdateInput updateDto,
        BookingReferenceWhereUniqueInput uniqueId
    )
    {
        var bookingReference = new BookingReferenceDbModel
        {
            Id = uniqueId.Id,
            MeetingId = updateDto.MeetingId,
            MeetingPassword = updateDto.MeetingPassword,
            MeetingUrl = updateDto.MeetingUrl,
            ExternalCalendarId = updateDto.ExternalCalendarId,
            Deleted = updateDto.Deleted
        };

        // map required fields
        if (updateDto.TypeField != null)
        {
            bookingReference.TypeField = updateDto.TypeField;
        }
        if (updateDto.Uid != null)
        {
            bookingReference.Uid = updateDto.Uid;
        }

        return bookingReference;
    }
}
