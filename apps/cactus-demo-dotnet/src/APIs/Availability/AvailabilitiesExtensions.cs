using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class AvailabilitiesExtensions
{
    public static Availability ToDto(this AvailabilityDbModel model)
    {
        return new Availability
        {
            Id = model.Id,
            User = model.UserId,
            EventType = model.EventTypeId,
            Days = model.Days,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            Date = model.Date,
            Schedule = model.ScheduleId,
        };
    }

    public static AvailabilityDbModel ToModel(
        this AvailabilityUpdateInput updateDto,
        AvailabilityWhereUniqueInput uniqueId
    )
    {
        var availability = new AvailabilityDbModel { Id = uniqueId.Id, Date = updateDto.Date };

        // map required fields
        if (updateDto.Days != null)
        {
            availability.Days = updateDto.Days.Value;
        }
        if (updateDto.StartTime != null)
        {
            availability.StartTime = updateDto.StartTime.Value;
        }
        if (updateDto.EndTime != null)
        {
            availability.EndTime = updateDto.EndTime.Value;
        }

        return availability;
    }
}
