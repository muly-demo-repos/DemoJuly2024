using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class DailyEventReferencesExtensions
{
    public static DailyEventReference ToDto(this DailyEventReferenceDbModel model)
    {
        return new DailyEventReference
        {
            Id = model.Id,
            Dailyurl = model.Dailyurl,
            Dailytoken = model.Dailytoken,
            Booking = model.BookingId,
        };
    }

    public static DailyEventReferenceDbModel ToModel(
        this DailyEventReferenceUpdateInput updateDto,
        DailyEventReferenceWhereUniqueInput uniqueId
    )
    {
        var dailyEventReference = new DailyEventReferenceDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.Dailyurl != null)
        {
            dailyEventReference.Dailyurl = updateDto.Dailyurl;
        }
        if (updateDto.Dailytoken != null)
        {
            dailyEventReference.Dailytoken = updateDto.Dailytoken;
        }

        return dailyEventReference;
    }
}
